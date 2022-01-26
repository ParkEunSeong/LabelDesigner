using DigitalProduction.Forms;
using iTextSharp.text.pdf;
using LabelEditor.data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabelEditor
{
    public partial class Form1 : Form
    {
        //1 mm =  2.83465 pt(point)
        //1 inch = 72 pt(point)
        //1 point = 1/72 inch
        //1 pixel = 1/96 inch(dpi 96)
        //Pixel 값 = (pointValue) * 96(dpi) / 72
        //Point 값 = (pixelValue) * 72 / 96(dpi)
        StatusBar statusBar1 = new StatusBar();
        // Create two StatusBarPanel objects to display in the StatusBar.
        StatusBarPanel m_statusBarPanel1 = new StatusBarPanel();
        StatusBarPanel m_statusBarPanel2 = new StatusBarPanel();

        private bool m_isDrag;
        private Point m_startPoint;
        private Control m_selectedCtrl;
        private NetClient m_netCient;
        public bool m_bQuit;
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn                            //파라미터
        (
            int nLeftRect,      // x-coordinate of upper-left corner
            int nTopRect,       // y-coordinate of upper-left corner
            int nRightRect,     // x-coordinate of lower-right corner
            int nBottomRect,    // y-coordinate of lower-right corner   
            int nWidthEllipse,  // height of ellipse
            int nHeightEllipse  // width of ellipse  
        );
        private frmMain m_labelSetForm;
        private List<RotatedLabel> m_labelList = new List<RotatedLabel>();
        private List<Barcode> m_barcodeList = new List<Barcode>();
        private List<QRCode> m_qrList = new List<QRCode>();
        private List<string> m_printerList = new List<string>();
        private Paper m_paper;
        private delegate void FromServerData(string json);
        private SelectControl m_select = new SelectControl();
        private Focus m_focus;
        private int CentimeterToPixel(int Centimeter)
        {
            double pixel = -1;
            using (Graphics g = this.CreateGraphics())
            {
                pixel = Centimeter * g.DpiY / 2.54d;
            }
            return (int)pixel;
        }

        private int PixelToCentimeter(int pixel)
        {
            return (int)(pixel * 2.54 / 287);
        }
        public void OnFromServerData(string json)
        {
            if (InvokeRequired)
            {
                var func = new FromServerData(OnFromServerData);
                Invoke(func, new object[] { json });
            }
            else
            {
                try
                {

                    var j = JObject.Parse(json);
                    foreach (var it in j.Properties())
                    {
                        if ( it.Name == "form_id" )
                        {
                            using (var sr = new StreamReader($"data/{it.Value}.json"))
                            {
                                var data = sr.ReadToEnd();
                                try
                                {
                                    m_paper = JsonConvert.DeserializeObject<Paper>(data);
                                    Initalize(m_paper);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("불러온 데이터 파일에 형식 오류가 있습니다.", "알림");
                                }
                            }
                        }
                        foreach (var jt in m_labelList)
                        {
                            if (jt.Name == it.Name)
                            {
                                jt.Text = it.Value.ToString();
                            }
                        }
                        foreach (var jt in m_qrList)
                        {
                            if (jt.Name == it.Name)
                            {
                                jt.Text = it.Value.ToString();
                            }
                        }
                        foreach (var jt in m_barcodeList)
                        {
                            if (jt.Name == it.Name)
                            {
                                jt.Text = it.Value.ToString();
                            }
                        }

                    }
                    buttonPrint_Click(null, null);


                }
                catch (Exception ex)
                {
                    TRACE.Log(ex.ToString());
                }
            }
        }
        public Form1()
        {

            InitializeComponent();
    
            CreateMyStatusBar();
            FormClosed += Form1_FormClosed;
         
            foreach ( string it in PrinterSettings.InstalledPrinters)
            {
                m_printerList.Add(it);
            }
            var a = PixelToCentimeter(2480);

            m_netCient = new NetClient("127.0.0.1", 9999);
            m_netCient.onComeData = delegate (string json)
            {
                OnFromServerData(json);

            };
            timer1.Start();
        }

    

        private void Canvas1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                if ( m_selectedCtrl != null )
                {
                    RemoveControl(m_selectedCtrl);
                }
            }
        }
        public void RemoveControl( Control ctrl )
        {
            var tag = ctrl.Tag.ToString();
            if ( tag == "0" )
            {
                m_labelList.Remove(ctrl as RotatedLabel);
            }
            else if ( tag == "1")
            {
                m_qrList.Remove(ctrl as QRCode);
            }
            else
            {
                m_barcodeList.Remove(ctrl as Barcode);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_bQuit = true;
            if (m_labelSetForm != null )
                m_labelSetForm.Close();
            timer1.Stop();
            if ( m_netCient != null )
                m_netCient.Close();
        }

        public void SetLabelFrom( frmMain frm )
        {
            m_labelSetForm = frm;
                Text = "LabelDesigner v1.0.0";
        }

        private void Canvas1_MouseUp(object sender, MouseEventArgs e)
        {
            m_selectedCtrl = null;
        }

        private void CreateFocus( Point location, Size size )
        {
            if (m_focus == null)
            {
                m_focus = new Focus();
                canvas1.Controls.Add(m_focus);
                m_focus.Image = Image.FromFile("qr.png");
                m_focus.SizeMode = PictureBoxSizeMode.StretchImage;
                m_focus.Tag = -1;
            }
            m_focus.Visible = true;
            m_focus.Width = size.Width;
            m_focus.Height = size.Height;
            m_focus.Location =location;
        }
        public void Initalize( Paper paper )
        {
            m_paper = paper;  
            labelMMSize.Text = $"{paper.MM_SIZE.Width}X{paper.MM_SIZE.Height}";
            labelPixel.Text = $"{paper.PAPER_SIZE.Width}X{paper.PAPER_SIZE.Height}";
            labelinch.Text = $"{paper.INCH_SIZE.Width}X{paper.INCH_SIZE.Height}";
            if ( canvas1 == null )
            {
                canvas1 = new Canvas();
                canvas1.Location = new Point(10, 10);
                canvas1.BackColor = Color.White;
                panel2.Controls.Add(canvas1);
            }
            canvas1.Width = paper.PAPER_SIZE.Width;
            canvas1.Height = paper.PAPER_SIZE.Height;
            canvas1.MouseMove += panel2_MouseMove;
            canvas1.MouseUp += Canvas1_MouseUp;
            canvas1.PreviewKeyDown += Canvas1_PreviewKeyDown;

            canvas1.Location = new Point(10,10);
            m_labelList.Clear();
            m_qrList.Clear();
            m_barcodeList.Clear();
            listBoxCtrl.Items.Clear();
            GC.Collect();
            canvas1.Controls.Clear();
        
            for ( int i = 0; i < paper.texts.Count; i++ )
            {
                var label = new RotatedLabel();
                label.AutoSize = true;
                label.Name = paper.texts[i].key;
                label.Location = new Point(paper.texts[i].x, paper.texts[i].y);
                label.Font = new Font(paper.texts[i].font_name, paper.texts[i].font_size, paper.texts[i].bold ? FontStyle.Bold : FontStyle.Regular);
                label.MouseDown += Label_MouseDown;
                label.MouseMove += Label_MouseMove;
                label.MouseUp += Label_MouseUp;
                label.Text = label.Name;
                label.Tag = 0;
                canvas1.Controls.Add(label);
                listBoxCtrl.Items.Add(label.Name + "-Text");
                m_labelList.Add(label );
                CreateFocus(label.Location, label.Size);

            }
            for (int i = 0; i < paper.qrs.Count; i++ )
            {
                var pb = new QRCode();
                pb.Name = paper.qrs[i].key;
                pb.Image = Image.FromFile("qr.png");
                pb.Width = paper.qrs[i].width;
                pb.Height = paper.qrs[i].height;
                pb.Text = pb.Name;
                pb.Location = new Point(paper.qrs[i].x, paper.qrs[i].y);
                pb.MouseDown += Label_MouseDown;
                pb.MouseMove += Label_MouseMove;
                pb.MouseUp += Label_MouseUp;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Tag = 1;
                canvas1.Controls.Add(pb);
                m_qrList.Add(pb);
                listBoxCtrl.Items.Add(pb.Name + "-QRCode");
            }
            for ( int i = 0; i < paper.barcodes.Count; i++ )
            {
                var pb = new Barcode();
                Image img = null;
                pb.Name = paper.barcodes[i].key;
                if ( paper.barcodes[i].barcode39 == 0 )
                {
                    Barcode39 barcode39 = new Barcode39();
                    barcode39.Code = "12345678";
                    barcode39.BarHeight = paper.barcodes[i].height;
                    img = barcode39.CreateDrawingImage(Color.Black, Color.White);
                }
                else
                {
                    Barcode128 barcode128 = new Barcode128();
                    barcode128.Code = "12345678";
                    barcode128.BarHeight = paper.barcodes[i].height;
                    img = barcode128.CreateDrawingImage(Color.Black, Color.White);
                }
                pb.Image = img;
                pb.Location = new Point(paper.barcodes[i].x, paper.barcodes[i].y);
                pb.Width = paper.barcodes[i].width;
                pb.Height = paper.barcodes[i].height;
                pb.MouseDown += Label_MouseDown;
                pb.MouseMove += Label_MouseMove;
                pb.MouseUp += Label_MouseUp;
                pb.Tag = 2;
                canvas1.Controls.Add(pb);
                m_barcodeList.Add(pb);
                listBoxCtrl.Items.Add(pb.Name + "-Barcode");
            }
                

        }


        public void Refresh(Paper paper)
        {
            Initalize( paper);
            panel2.Invalidate();
        }

        private void CreateMyStatusBar()
        {
            m_statusBarPanel1.BorderStyle = StatusBarPanelBorderStyle.Sunken;
            m_statusBarPanel1.Text = "Ready...";
            m_statusBarPanel1.AutoSize = StatusBarPanelAutoSize.Spring;
            m_statusBarPanel2.BorderStyle = StatusBarPanelBorderStyle.Raised;
            m_statusBarPanel2.ToolTipText = "Started: " + System.DateTime.Now.ToShortTimeString();
            m_statusBarPanel2.Text = System.DateTime.Today.ToLongDateString();
            m_statusBarPanel2.AutoSize = StatusBarPanelAutoSize.Contents;
            statusBar1.ShowPanels = true;		
            statusBar1.Panels.Add(m_statusBarPanel1);
            statusBar1.Panels.Add(m_statusBarPanel2);
            this.Controls.Add(statusBar1);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if ( m_selectedCtrl != null )
            {
                m_statusBarPanel1.Text = $"position:{m_selectedCtrl.Location.X},{m_selectedCtrl.Location.Y}";
            }
            else
            {
                m_statusBarPanel1.Text = "";
            }
            //m_statusBarPanel1.Text = $"mm:{Math.Truncate(e.X/2.8f)},{Math.Truncate(e.Y/2.8f)}";
        }

        private void OnButtonClickedMakeControl(object sender, EventArgs e)
        {
            var tag = (sender as Control).Tag;
            if (tag.ToString() == "0")
            {
                var label = new DigitalProduction.Forms.RotatedLabel();
                label.Name = "label" + canvas1.Controls.Count;
                label.Location = new Point(100, 100);
                label.Font = new Font("맑은 고딕", 14, FontStyle.Regular);
                label.Text = label.Name;
                label.AutoSize = true;
                label.Height = (int)(label.Font.Size*2);
                label.MouseDown += Label_MouseDown;
                label.MouseMove += Label_MouseMove;
                label.MouseUp += Label_MouseUp;
               
                label.Tag = 0;
                canvas1.Controls.Add(label);
                m_labelList.Add(label);
                listBoxCtrl.Items.Add(label.Name + "-Text");

            }
            else if (tag.ToString() == "1")
            {
                var pb = new QRCode();
                pb.Name = "qrcode" + canvas1.Controls.Count;
                pb.Image = Image.FromFile("qr.png");
                pb.Width = 50;
                pb.Height = 50;
                pb.Text = pb.Name;
                pb.Location = new Point(100, 100);
                pb.MouseDown += Label_MouseDown;
                pb.MouseMove += Label_MouseMove;
                pb.MouseUp += Label_MouseUp;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Tag = 1;
                canvas1.Controls.Add(pb);
                m_qrList.Add(pb);
                listBoxCtrl.Items.Add(pb.Name + "-QRCode");
                m_select.SetControl(pb);
            }
            else
            {
                Barcode39 barcode39 = new Barcode39();
                barcode39.Code = "12345678";
                barcode39.BarHeight = 30;
                var img = barcode39.CreateDrawingImage(Color.Black, Color.White);

                var pb = new Barcode();
                pb.Name = "barcode" + canvas1.Controls.Count;
                pb.Location = new Point(100, 100);
                pb.Width = 80;
                pb.Height = 20;
                pb.MouseDown += Label_MouseDown;
                pb.MouseMove += Label_MouseMove;
                pb.Image = img;
                pb.MouseUp += Label_MouseUp;
                pb.Tag = 2;
                canvas1.Controls.Add(pb);
                m_barcodeList.Add(pb);
                listBoxCtrl.Items.Add(pb.Name + "-Barcode");
                m_select.SetControl(pb);
            }
        
        }
        private void Label_MouseUp(object sender, MouseEventArgs e)
        {
            m_isDrag = false;
        }

        private void Label_MouseMove(object sender, MouseEventArgs e)
        {
            Control ctrl = sender as Control;
            if (m_isDrag)
            {
                ctrl.Left = e.X + ctrl.Left - m_startPoint.X;
                if (ctrl.Left < 0)
                {
                    ctrl.Left = 0;
                }
                else if (ctrl.Left > (canvas1.Width + ctrl.Width))
                    ctrl.Left = canvas1.Width;
                ctrl.Top = e.Y + ctrl.Top - m_startPoint.Y;
                if (ctrl.Top < 0)
                {
                    ctrl.Top = 0;
                }
                else if (ctrl.Top > (canvas1.Height + ctrl.Height ))
                    ctrl.Height = canvas1.Height;
                ctrl.Invalidate();
                m_select.OnDraw();
                SetSelectedControl(m_selectedCtrl);
            }
       
        }

        private void Label_MouseDown(object sender, MouseEventArgs e)
        {
            var ctrl = sender as Control;
            if (e.Button == MouseButtons.Left)
            {
                m_isDrag = true;
                m_startPoint = e.Location;
            }
            else
            {
                if (ctrl is RotatedLabel)
                {
                    var form = new PropertyTextForm();
                    form.SetLabel(ctrl as RotatedLabel);
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.FormClosed += Form_FormClosed;
                    form.Show();
                }
                else if (ctrl is Barcode)
                {
                    var form = new PropertyBarcodeForm();
                    form.SetLabel(ctrl as Barcode);
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.FormClosed += Form_FormClosed;
                    form.Show();
                }
                else if (ctrl is QRCode)
                {
                    var form = new PropertyQRForm();
                    form.SetQR(ctrl as QRCode);
                    form.FormClosed += Form_FormClosed;
                    form.Show();
                }
               
           }

                m_selectedCtrl = ctrl;
       //     panelParent.Invalidate();
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefreshListBox();
        }

        public void SetSelectedControl( Control ctrl )
        {
            if (ctrl == null)
                return;



        }
        private void 새파일ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 불러오기ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 저장하기ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 다른이름으로저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshPrinterList();
            
        }
        
        private bool IntersectRect( Point pt )
        {
            for( int i = 0; i < m_labelList.Count; i++ )
            {
                if (m_labelList[i].Location.X <= pt.X &&
                    pt.X <= m_labelList[i].Location.X + m_labelList[i].Width &&
                    m_labelList[i].Location.Y <= pt.Y &&
                    pt.Y <= m_labelList[i].Location.Y + m_labelList[i].Height )
                {
                    return true;
                }
                    
            }
            return false;
        }


        private void buttonPrint_Click(object sender, EventArgs e)
        {
            PrintDocument doc = new PrintDocument();
            
            doc.PrinterSettings = new PrinterSettings();
            doc.DefaultPageSettings.PaperSize = new PaperSize("Custom", m_paper.PAPER_SIZE.Width, m_paper.PAPER_SIZE.Height);
            doc.DefaultPageSettings.Landscape = m_paper.orientation == 1 ? false : true;
            if (listBoxPrinter.SelectedItem == null)
            {
                if (listBoxPrinter.Items.Count > 0 && listBoxPrinter.SelectedItem == null)
                    listBoxPrinter.SelectedIndex = 0;
                else
                {
                    MessageBox.Show("출력가능한 프린터가 설정되지 않았습니다.", "알림");
                    return;
                }
            }
            
            doc.PrinterSettings.PrinterName = listBoxPrinter.SelectedItem.ToString();
            if (doc.PrinterSettings.PrinterName.Contains("PDF"))
            {
                doc.PrinterSettings.PrintFileName = @"C:\trace\test.pdf";
            }

            //doc.OriginAtMargins
            doc.PrinterSettings.PrintRange = PrintRange.Selection;
            doc.PrinterSettings.FromPage = 0;
            doc.PrinterSettings.ToPage = 0;
             doc.PrintPage += Doc_PrintPage;
            doc.EndPrint += Doc_EndPrint;
            doc.Print();
        }

        private void Doc_EndPrint(object sender, PrintEventArgs e)
        {
            Initalize(m_paper);
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (var it in m_labelList)
            {

                PointF drawPoint = new PointF(it.Location.X, it.Location.Y); // 좌측 상단 시작점. // 2중 using 문 사용.

                using (Font font = new Font("맑은 고딕", it.Font.Size))
                {
                    using (SolidBrush drawBrush = new SolidBrush(Color.Black))
                    {
                        g.DrawString(it.Text, font, drawBrush, drawPoint);
                    }
                }
            }
            foreach( var it in m_qrList )
            {
                ZXing.BarcodeWriter barcodeWriter = new ZXing.BarcodeWriter();
                barcodeWriter.Format = ZXing.BarcodeFormat.QR_CODE;

                barcodeWriter.Options.Width = it.Width;
                barcodeWriter.Options.Height = it.Height;

                string strQRCode = it.Text; 

                Image img = barcodeWriter.Write(strQRCode);
                g.DrawImage(img, it.Location.X, it.Location.Y, it.Width, it.Height);
                img.Dispose();
            }
            foreach( var it in m_barcodeList )
            {
                if (it.code39 == 1)
                {
                    Barcode39 barcode39 = new Barcode39();
                    barcode39.Code = it.Text;
                    barcode39.BarHeight = it.Height;
                    var img = barcode39.CreateDrawingImage(Color.Black, Color.White);
                    g.DrawImage(img, it.Location.X, it.Location.Y, it.Width, it.Height);
                    img.Dispose();
                }
                else
                {
                    Barcode128 barcode128 = new Barcode128();
                    barcode128.Code = it.Text;
                    barcode128.BarHeight = it.Height;
                    var img = barcode128.CreateDrawingImage(Color.Black, Color.White);
                    g.DrawImage(img, it.Location.X, it.Location.Y, it.Width, it.Height);
                    img.Dispose();
                
                }

            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

  
        }

        private void DrawText( Graphics g, int x, int y, string text)
        {
          
            // Create font and brush.
            Font drawFont = new Font("맑은 고딕", 8);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Set format of string.
            StringFormat drawFormat = new StringFormat();
         //   drawFormat.FormatFlags = StringFormatFlags.;

            // Draw string to screen.
        ///  g.DrawString(text, drawFont, drawBrush, x, y, drawFormat);
        }

        private void checkBoxBold_CheckedChanged(object sender, EventArgs e)
        {
            if ( fontDialog1.ShowDialog() == DialogResult.OK )
            {
                m_selectedCtrl.Font = fontDialog1.Font;
                SetSelectedControl(m_selectedCtrl);
            }
        }

        private void textBoxFontSize_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                m_selectedCtrl.Font = fontDialog1.Font;
                SetSelectedControl(m_selectedCtrl);
            }
        }

        public void RefreshListBox()
        {
            listBoxCtrl.Items.Clear();
            foreach( Control it in canvas1.Controls )
            {
                if (it.Tag.ToString() == "0")
                {
                    listBoxCtrl.Items.Add(it.Name + "-Text");
                }
                else if (it.Tag.ToString() == "1")
                {
                    listBoxCtrl.Items.Add(it.Name + "-QRCode");
                }
                else
                {
                    listBoxCtrl.Items.Add(it.Name + "-Barcode");
                }
            }
        }

        private void comboBoxRotation_SelectedIndexChanged(object sender, EventArgs e)
        {
   
        }

        private void buttonLabelSetting_Click(object sender, EventArgs e)
        {
            m_labelSetForm.Visible = !m_labelSetForm.Visible;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            
            var json = new JObject();
            foreach (var it in m_labelList )
            {
                var text = new Text();
                text.key = it.Name; 
                text.font_name = it.Font.Name;
                text.font_size = (int)it.Font.Size;
                text.rotation = PropUtil.GetAngleToIdx( it.Angle);
                text.x = it.Location.X;
                text.y = it.Location.Y;

                m_paper.texts.Add(text);
            }
            foreach( var it in m_barcodeList )
            {
                var barcode = new data.Barcode();
                barcode.key = it.Name;
                barcode.x = it.Location.X;
                barcode.y = it.Location.Y;
                barcode.width = it.Width;
                barcode.height = it.Height;
                barcode.barcode39 = it.code39;
                m_paper.barcodes.Add(barcode);
            }
            foreach(var it in m_qrList )
            {
                var qr = new QR();
                qr.key = it.Name;
                qr.width = it.Width;
                qr.height = it.Height;
                qr.x = it.Location.X;
                qr.y = it.Location.Y;
                m_paper.qrs.Add(qr);
            }
            var jsonObject = JsonConvert.SerializeObject(m_paper);

            var form = new SetFileNameForm();
            form.OnApply = delegate (string fileName)
            {
                using (var sw = new StreamWriter(@"data\"+fileName + ".json"))
                {
                    sw.Write(jsonObject);
                }
            };

            form.ShowDialog();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = Environment.CurrentDirectory;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var filePath = dlg.FileName;
                using (var sr = new StreamReader(filePath))
                {
                    var data = sr.ReadToEnd();
                    try
                    {
                        m_paper = JsonConvert.DeserializeObject<Paper>(data);
                        Initalize(m_paper);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("불러온 데이터 파일에 형식 오류가 있습니다.", "알림");
                    }
                }
            }

        }
      

        private void buttonRefreshPrinter_Click(object sender, EventArgs e)
        {

            RefreshPrinterList();
        }
        private void RefreshPrinterList()
        {
            listBoxPrinter.Items.Clear();
            foreach (string it in PrinterSettings.InstalledPrinters)
            {
                if (!it.Contains("XPS") && !it.Contains("Fax") && !it.Contains("PDF"))
                    listBoxPrinter.Items.Add(it);
            }
        }

        private void panel2_Scroll(object sender, ScrollEventArgs e)
        {
            panel2.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if ( m_netCient != null )
                m_netCient.TryCnnnect();
            timer1.Start();
        }

        private void listBoxCtrl_MouseDown(object sender, MouseEventArgs e)
        {
            if ( m_selectedCtrl != null )
            {
                if ( e.Button == MouseButtons.Right )
                {
                    if (m_selectedCtrl is RotatedLabel)
                    {
                        var form = new PropertyTextForm();
                        form.SetLabel(m_selectedCtrl as RotatedLabel);
                        form.StartPosition = FormStartPosition.CenterScreen;
                        form.FormClosed += Form_FormClosed;
                        form.Show();
                    }
                    else if (m_selectedCtrl is Barcode)
                    {
                        var form = new PropertyBarcodeForm();
                        form.SetLabel(m_selectedCtrl as Barcode);
                        form.StartPosition = FormStartPosition.CenterScreen;
                        form.FormClosed += Form_FormClosed;
                        form.Show();
                    }
                    else if (m_selectedCtrl is QRCode)
                    {
                        var form = new PropertyQRForm();
                        form.SetQR(m_selectedCtrl as QRCode);
                        form.FormClosed += Form_FormClosed;
                        form.Show();
                    }
                }
            }
        }

        private void listBoxCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedName = listBoxCtrl.SelectedItem.ToString();
            var split = selectedName.Split('-');
            
            foreach ( Control it in canvas1.Controls )
            {
                if ( split[0] == it.Name && it.Tag.ToString() == "0")
                {
                    var form = new PropertyTextForm();
                    form.SetLabel(it as RotatedLabel);
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.FormClosed += Form_FormClosed;
                    form.Show();
                }
                else if (split[0] == it.Name && it.Tag.ToString() == "1")
                {
                    var form = new PropertyQRForm();
                    form.SetQR(it as QRCode);
                    form.FormClosed += Form_FormClosed;
                    form.Show();
                }
                else if ( split[0] == it.Name && it.Tag.ToString() == "2" )
                {

                    var form = new PropertyBarcodeForm();
                    form.SetLabel(it as Barcode);
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.FormClosed += Form_FormClosed;
                    form.Show();
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            canvas1.Controls.Clear();
            RefreshListBox();
        }

        private void listBoxPrinter_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
