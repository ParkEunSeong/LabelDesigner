using DigitalProduction.Forms;
using iTextSharp.text.pdf;
using LabelEditor.data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RotatePictureBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;

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
        private bool m_printButton;
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
        private List<RotatedLabel> m_dataTimeList = new List<RotatedLabel>();
        private List<string> m_printerList = new List<string>();
        private Paper m_paper;
        private delegate void FromServerData(string json);
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
                    JObject j = null;
                    try
                    {
                        j = JObject.Parse(json);
                    }
                    catch (Exception ex)
                    {
                        TRACE.Log(ex.ToString());
                    }

                    foreach (var it in j.Properties())
                    {
                        if (it.Name == "form_id")
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
                        foreach ( var jt in m_dataTimeList )
                        {
                            if (jt.Name == it.Name)
                            {
                                jt.Text = it.Value.ToString();
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    TRACE.Log(ex.ToString());
                }
                Print();
            }
        }
        public void Print()
        {
            m_printButton = false;
            buttonPrint_Click(null, null);
        }
        public Form1()
        {

            InitializeComponent();

            CreateMyStatusBar();
            FormClosed += Form1_FormClosed;
            foreach (string it in PrinterSettings.InstalledPrinters)
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

        public void RemoveControl(Control ctrl)
        {
            var tag = ctrl.Tag.ToString();
            if (tag == "0")
            {
                m_labelList.Remove(ctrl as RotatedLabel);
            }
            else if (tag == "1")
            {
                m_qrList.Remove(ctrl as QRCode);
            }
            else if ( tag == "3" )
            {
                m_dataTimeList.Remove(ctrl as RotatedLabel);
            }
            else
            {
                m_barcodeList.Remove(ctrl as Barcode);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                m_bQuit = true;
                if (m_labelSetForm != null)
                    m_labelSetForm.Close();
                timer1.Stop();
                if (m_netCient != null)
                    m_netCient.Close();
            }
            catch (Exception ex)
            {
                TRACE.Log(ex.ToString());
            }
        }

        public void SetLabelFrom(frmMain frm)
        {
            m_labelSetForm = frm;
            Text = "LabelDesigner v1.0.0";
        }

        private void Canvas1_MouseUp(object sender, MouseEventArgs e)
        {
            m_selectedCtrl = null;
        }


        public void Initalize(Paper paper, bool print = false)
        {
            try
            {
                m_paper = paper;
                labelMMSize.Text = $"{paper.MM_SIZE.Width}X{paper.MM_SIZE.Height}";
                labelPixel.Text = $"{paper.PAPER_SIZE.Width}X{paper.PAPER_SIZE.Height}";
                labelinch.Text = $"{paper.INCH_SIZE.Width}X{paper.INCH_SIZE.Height}";
                if (canvas1 == null)
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

                canvas1.Location = new Point(10, 10);
                if (print == false)
                {
                    m_labelList.Clear();
                    m_qrList.Clear();
                    m_barcodeList.Clear();
                    m_dataTimeList.Clear();
              
                    GC.Collect();
                    canvas1.Controls.Clear();
                    listViewControl.Items.Clear();
                }
               


                TRACE.Log("texts");
                for (int i = 0; i < paper.texts.Count; i++)
                {
                    var label = new RotatedLabel();
                    label.AutoSize = true;
                    label.Name = paper.texts[i].key;
                    label.Location = new Point(paper.texts[i].x, paper.texts[i].y);
                    label.Font = new Font(paper.texts[i].font_name, paper.texts[i].font_size, paper.texts[i].bold ? FontStyle.Bold : FontStyle.Regular);
                    label.MouseDown += Label_MouseDown;
                    label.MouseMove += Label_MouseMove;
                    label.MouseUp += Label_MouseUp;
                    label.Fix = paper.texts[i].Fix;
                    label.Text = label.Name;
                    label.Tag = 0;
                    label.Selected();
                    for (int j = 0; j < 5; j++)
                    {
                        label.m_multple.Add(new data.Text(paper.texts[i].m_multiple[j].key, paper.texts[i].m_multiple[j].Fix));
                    }
                    canvas1.Controls.Add(label);
                    var item = new ListViewItem(label.Name);
                    item.SubItems.Add("Text");
                    listViewControl.Items.Add(item);
                    m_labelList.Add(label);
                }
                TRACE.Log("datetimes");
                for (int i = 0; i < paper.dateTimes.Count; i++)
                {
                    var label = new RotatedLabel();
                    label.AutoSize = true;
                    label.Name = paper.dateTimes[i].key;
                    label.Location = new Point(paper.dateTimes[i].x, paper.dateTimes[i].y);
                    label.Font = new Font(paper.dateTimes[i].font_name, paper.dateTimes[i].font_size, paper.dateTimes[i].bold ? FontStyle.Bold : FontStyle.Regular);
                    label.MouseDown += Label_MouseDown;
                    label.MouseMove += Label_MouseMove;
                    label.MouseUp += Label_MouseUp;
                    label.m_dateTimeFormat = paper.dateTimes[i].datetime_type;
                    label.Text = label.Name;
                    label.Tag = 3;
                    label.Selected();
 
                    canvas1.Controls.Add(label);
                    var item = new ListViewItem(label.Name);
                    item.SubItems.Add("DaateTime");
                    listViewControl.Items.Add(item);
                    m_dataTimeList.Add(label);
                }
                TRACE.Log("qrs");
                for (int i = 0; i < paper.qrs.Count; i++)
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
                    var item = new ListViewItem(pb.Name);
                    item.SubItems.Add("QRCode");
                    listViewControl.Items.Add(item);
                }
                TRACE.Log("barcodes");
                for (int i = 0; i < paper.barcodes.Count; i++)
                {
                    var pb = new Barcode();
                    Image img = null;
                    pb.Name = paper.barcodes[i].key;
                    pb.Padding = paper.barcodes[i].Padding;
                    pb.code39 = paper.barcodes[i].barcode39;
                  
                    if (paper.barcodes[i].barcode39 == 0)
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
                    var item = new ListViewItem(pb.Name);
                    item.SubItems.Add("Barcode");
                    listViewControl.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                TRACE.Log(ex.ToString());
            }


        }


        public void Refresh(Paper paper)
        {
            Initalize(paper);
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
            if (m_selectedCtrl != null)
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
            ListViewItem item = null; 
            if (tag.ToString() == "0")
            {
                var label = new DigitalProduction.Forms.RotatedLabel();
                label.Name = "label" + canvas1.Controls.Count;
                label.Location = new Point((int)(canvas1.Width * 0.5f), (int)(canvas1.Height * 0.5f));
                label.Font = new Font("맑은 고딕", 14, FontStyle.Regular);
                label.Text = label.Name;
                label.AutoSize = true;
                label.Height = (int)(label.Font.Size * 2);
                label.MouseDown += Label_MouseDown;
                label.MouseMove += Label_MouseMove;
                label.MouseUp += Label_MouseUp;
                for (int j = 0; j < 5; j++)
                {
                    label.m_multple.Add(new data.Text());
                }
                var ran = new Random();
                label.Id = ran.Next(0, 10000);
                label.Tag = 0;
                canvas1.Controls.Add(label);
                m_labelList.Add(label);
                item = new ListViewItem(label.Name);
                item.SubItems.Add("Text");
                item.Tag = label.Id;
                label.Selected();

            }
            else if (tag.ToString() == "1")
            {
                var pb = new QRCode();
                pb.Name = "qrcode" + canvas1.Controls.Count;
                pb.Image = Image.FromFile("qr.png");
                pb.Width = 50;
                pb.Height = 50;
                pb.Text = pb.Name;
                pb.Location = new Point((int)(canvas1.Width * 0.5f), (int)(canvas1.Height * 0.5f));
                pb.MouseDown += Label_MouseDown;
                pb.MouseMove += Label_MouseMove;
                pb.MouseUp += Label_MouseUp;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                var ran = new Random();
                pb.Id = ran.Next(10000, 20000);
                pb.Tag = 1;
                canvas1.Controls.Add(pb);
                m_qrList.Add(pb);
                item = new ListViewItem(pb.Name);
                item.SubItems.Add("QRCode");
                item.Tag = pb.Id;
                pb.Selected();

            }
            else if ( tag.ToString() == "3" )
            {
                var label = new DigitalProduction.Forms.RotatedLabel();
                label.Name = "datetime" + canvas1.Controls.Count;
                label.Location = new Point( (int)(canvas1.Width * 0.5f), (int)(canvas1.Height * 0.5f));
                label.Font = new Font("맑은 고딕", 14, FontStyle.Regular);
                label.Text = label.Name;
                label.AutoSize = true;
                label.Height = (int)(label.Font.Size * 2);
                label.MouseDown += Label_MouseDown;
                label.MouseMove += Label_MouseMove;
                label.MouseUp += Label_MouseUp;
                var ran = new Random();
                label.Id = ran.Next(20000, 30000);
                label.Tag = 3;
                canvas1.Controls.Add(label);
                m_dataTimeList.Add(label);
                item = new ListViewItem(label.Name);
                item.SubItems.Add("DateTime");
                item.Tag = label.Id;
                label.Selected();
            }
            else
            {
                Barcode39 barcode39 = new Barcode39();
                barcode39.Code = "12345678";
                barcode39.BarHeight = 30;

                var img = barcode39.CreateDrawingImage(Color.Black, Color.White);

                var pb = new Barcode();
                pb.Padding = 5;
                var ran = new Random();
                pb.Id = ran.Next(30000, 40000);
                pb.Name = "barcode" + canvas1.Controls.Count;
                pb.Location = new Point((int)(canvas1.Width * 0.5f), (int)(canvas1.Height * 0.5f));
                pb.Width = 100;
                pb.Height = 30;
                pb.MouseDown += Label_MouseDown;
                pb.MouseMove += Label_MouseMove;
                pb.Image = img;
                pb.MouseUp += Label_MouseUp;
                pb.Tag = 2;
                canvas1.Controls.Add(pb);
                m_barcodeList.Add(pb);
                item = new ListViewItem(pb.Name);
                item.SubItems.Add("Barcode");
                item.Tag = pb.Id;
                pb.Selected();
            }
            if ( item != null )
            {
                listViewControl.Items.Add(item);
            }

        }
        private void Label_MouseUp(object sender, MouseEventArgs e)
        {
            m_isDrag = false;
            var ctrl = (sender as Control);
            if (ctrl is RotatedLabel)
            {
                ((RotatedLabel)ctrl).UnSelected();
            }
            else if (ctrl is QRCode)
            {
                ((QRCode)ctrl).UnSelected();
            }
            else if (ctrl is Barcode)
            {
                ((Barcode)ctrl).UnSelected();
            }
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
                else if (ctrl.Top > (canvas1.Height + ctrl.Height))
                    ctrl.Height = canvas1.Height;
            }

        }
        private void RemoveControl(string name, string strType)
        {
            foreach ( ListViewItem it in listViewControl.Items)
            {
                var itemName = it.SubItems[0].Text;
                var itemType = it.SubItems[1].Text;
              
                if (itemName == name && strType == itemType)
                {
                    listViewControl.Items.Remove(it);
                    break;
                }
            }
        }
        private void SelectedListBox( string name )
        {
            return;
        
        }
        private void Label_MouseDown(object sender, MouseEventArgs e)
        {
            var ctrl = sender as Control;
            if (e.Button == MouseButtons.Left)
            {
                m_isDrag = true;
                m_startPoint = e.Location;
                if (ctrl is RotatedLabel)
                {
                    ((RotatedLabel)ctrl).Selected();
                    if ( ctrl.Tag.ToString() == "0")
                    {
                        SelectedListBox($"{ctrl.Name}-Text");
                    }
                    else
                    {
                        SelectedListBox($"{ctrl.Name}-DateTime");
                    }
                }
                else if (ctrl is QRCode)
                {
                    ((QRCode)ctrl).Selected();
                    SelectedListBox($"{ctrl.Name}-QRCode");
                }
                else if (ctrl is Barcode)
                {
                    ((Barcode)ctrl).Selected();
                    SelectedListBox($"{ctrl.Name}-Barcode");
                }
                m_selectedCtrl = ctrl;
            }
            else
            {
                try
                {
                    if (ctrl is RotatedLabel)
                    {

                        if (ctrl.Tag.ToString() == "0")
                        {
                            m_labelList.Remove(((RotatedLabel)ctrl));
                            ((RotatedLabel)ctrl).Selected();
                            RemoveControl(ctrl.Name, "Text");
                        }
                        else
                        {
                            m_dataTimeList.Remove(((RotatedLabel)ctrl));
                            ((RotatedLabel)ctrl).Selected();
                            RemoveControl(ctrl.Name, "DateTime");
                        }

                    }
                 
                    else if (ctrl is QRCode)
                    {
                        m_qrList.Remove(((QRCode)ctrl));
                        ((QRCode)ctrl).Selected();
                        RemoveControl(ctrl.Name, "QRCode");

                    }
                    else if (ctrl is Barcode)
                    {
                        m_barcodeList.Remove(((Barcode)ctrl));
                        ((Barcode)ctrl).Selected();
                        RemoveControl(ctrl.Name, "Barcode");
                    }
                    canvas1.Controls.Remove(ctrl);
                }
                catch (Exception ex)
                {
                    TRACE.Log(ex.ToString());
                }

            }


            //     panelParent.Invalidate();
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ( sender is PropertyTextForm)
            {
                m_textForm = null;
            }
            else if (sender is PropertyDateTimeForm)
            {
                m_dateTimeForm = null;
            }
            else if ( sender is PropertyBarcodeForm)
            {
                m_barcodeForm = null;
            }
            else if ( sender is PropertyQRForm)
            {
                m_qrForm = null;
            }
            RefreshListBox();
        }

        public void SetSelectedControl(Control ctrl)
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

        private bool IntersectRect(Point pt)
        {
            for (int i = 0; i < m_labelList.Count; i++)
            {
                if (m_labelList[i].Location.X <= pt.X &&
                    pt.X <= m_labelList[i].Location.X + m_labelList[i].Width &&
                    m_labelList[i].Location.Y <= pt.Y &&
                    pt.Y <= m_labelList[i].Location.Y + m_labelList[i].Height)
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
            PrintController printController = new StandardPrintController();
            doc.PrintController = printController;
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
            if (sender != null)
                m_printButton = true;
            doc.Print();
        }

        private void Doc_EndPrint(object sender, PrintEventArgs e)
        {
            if (m_printButton)
            {
                Initalize(m_paper, true);
            }
        }
        private void DrawRotatedTextAt(Graphics gr, float angle, string txt, int x, int y, Font font, Brush the_brush)
        {
            if (angle != 0 )
            {
                x -= (int)font.Size;
                y -= (int)font.Size;
            }
            // Save the graphics state.
            GraphicsState state = gr.Save();
            gr.ResetTransform();

            // Rotate.
            gr.RotateTransform(angle);

            // Translate to desired position. Be sure to append
            // the rotation so it occurs after the rotation.
            gr.TranslateTransform(x, y, MatrixOrder.Append);

            // Draw the text at the origin.
            gr.DrawString(txt, font, the_brush,0,0);

            // Restore the graphics state.
            gr.Restore(state);
        }
        private Bitmap RoateImage(Bitmap src, float angle)
        {
            Bitmap trg = new Bitmap(src.Width, src.Height);
            Graphics g = Graphics.FromImage(trg); // 이미지 중심을 (0,0)으로 이동
            g.TranslateTransform(src.Width / 2, src.Height / 2); // 회전
            g.RotateTransform(angle); // 이미지 중심 원래 자표로 이동 
            g.TranslateTransform(-src.Width / 2, -src.Height / 2); // 원본 이미지로 그리기
            g.DrawImage(src, new Point(0, 0));
            return trg;
        }

       
        public string ParseStrDateTime( string text, int s, int e )
        {
            try
            {
                return text.Substring(s, e);
            }
            catch(Exception ex)
            {
                TRACE.Log(text + ", " + s + "," + e + "," + ex.ToString());
                
            }
            return "";
        }
        public string ConvertDateTime( string text, int format )
        {
            string year = ParseStrDateTime(text, 0, 4);
            string month = ParseStrDateTime(text, 4, 2);
            string day = ParseStrDateTime(text, 6, 2);
            string hour = ParseStrDateTime(text, 8, 2);
            string min = ParseStrDateTime(text, 10, 2);

            if (format == 0)
                return text;
            else if (format == 1)
            {
                year = ParseStrDateTime(year, 2, 2);
                if (!string.IsNullOrEmpty(hour))
                    return $"{year}-{month}-{day} {hour}:{min}";
                else
                    return $"{year}-{month}-{day}";
            }
            else if ( format == 2 )
            {
                if ( !string.IsNullOrEmpty(hour ))
                    return $"{year}-{month}-{day} {hour}:{min}";
                else
                    return $"{year}-{month}-{day}";
            }
            else if ( format == 3 )
            {
                year = ParseStrDateTime(year, 2, 2);
                if (!string.IsNullOrEmpty(hour))
                    return $"{year}년{month}월{day}일 {hour}시{min}분";
                else
                    return $"{year}년{month}월{day}일";
            }
            else
            {
                if (!string.IsNullOrEmpty(hour))
                    return $"{year}년{month}월{day}일 {hour}시{min}분";
                else
                    return $"{year}년{month}월{day}일";
            }
        }
        public static Bitmap Generate2( BarcodeFormat format, string text, int width, int height, int padding )
        {
            BarcodeWriter writer = new BarcodeWriter();
            //  ITF   ，           、     
            //              CODE_128   
            //writer.Format = BarcodeFormat.ITF;
            writer.Format = format;
            EncodingOptions options = new EncodingOptions()
            {
                PureBarcode = true,
                Width = width,
                Height = height,
                Margin = padding
            };
            writer.Options = options;
            Bitmap map = writer.Write(text);
            return map;
        }
        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (var it in m_labelList)
            {

                PointF drawPoint = new PointF(it.Location.X, it.Location.Y); // 좌측 상단 시작점. // 2중 using 문 사용.
                Font font = it.Font;
                string text = it.Text;
                if (it.Multiple)
                {
                    text = "";
                    foreach (var jt in it.m_multple)
                    {
                        if (string.IsNullOrEmpty(jt.content))
                            text += jt.key;
                        else
                            text += jt.content;
                    }
                }
                else if (it.IsArray)
                {
                    if (it.Fix == false)
                    {
                    
           
                            try
                            {
                            var j = new JArray();
                            j.Add("1111");
                            j.Add("Luna");
                            j.Add("1234");
                            var jarr = j;
                             text = " ";
                                foreach (var kt in jarr)
                                {
                                text += kt + it.Separator;
                                }
                                if (text.Length > 0)
                                text = text.Substring(0, text.Length - 1);

                            }
                            catch (Exception ex)
                            {
                                TRACE.Log(ex.ToString());
                            }
                        
                    }
                }
                using (SolidBrush drawBrush = new SolidBrush(Color.Black))
                {

                    DrawRotatedTextAt(g, it.Angle, text, (int)drawPoint.X, (int)drawPoint.Y, font, drawBrush);
                    //g.DrawString(it.Text, font, drawBrush, 0, 0);
                }

            }
            foreach (var it in m_dataTimeList)
            {

                PointF drawPoint = new PointF(it.Location.X, it.Location.Y); // 좌측 상단 시작점. // 2중 using 문 사용.
                Font font = it.Font;

                using (SolidBrush drawBrush = new SolidBrush(Color.Black))
                {
                    if (string.IsNullOrEmpty(it.Text) || !string.IsNullOrEmpty(it.Text) && it.Text.Contains("datetime"))
                        it.Text = DateTime.Now.ToString("yyyyMMddHHmm");
                    var str = ConvertDateTime(it.Text, it.m_dateTimeFormat);
                    TRACE.Log($"dateTime {it.Text}, {it.Anchor}, {str}, {it.m_dateTimeFormat}");
                    DrawRotatedTextAt(g, it.Angle, str, (int)drawPoint.X, (int)drawPoint.Y, font, drawBrush);
                    it.Text = it.Name;
                    //g.DrawString(it.Text, font, drawBrush, 0, 0);

                }

            }
            foreach (var it in m_qrList)
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
            PrivateFontCollection privateFont = new PrivateFontCollection();
         
          
            foreach (var it in m_barcodeList)
            {
                if (it.font)
                {
                    PointF drawPoint = new PointF(it.Location.X, it.Location.Y); // 좌측 상단 시작점. // 2중 using 문 사용.
                    if (string.IsNullOrEmpty(it.Text))
                        it.Text = "12345678";
                    TRACE.Log("Barcode Text=" + it.Text + "," + it.Location.X + "," + it.Location.Y);
                    if ( it.code39 ==0)
                    {
      
                        privateFont.AddFontFile(Environment.CurrentDirectory + @"\font\code39.ttf");
                        using (Font font = new Font(privateFont.Families[0], it.Height))
                        {
                            using (SolidBrush drawBrush = new SolidBrush(Color.Black))
                            {
                                // DrawRotatedTextAt(g, it.Angle, it.Text, (int)drawPoint.X, (int)drawPoint.Y, font, drawBrush);
                                TRACE.Log("Font39 Barcode = " + it.Text);
                                g.DrawString("*" + it.Text + "*", font, drawBrush, drawPoint);
                            }
                        }
                    }
                    else
                    {
                        privateFont.AddFontFile(Environment.CurrentDirectory + @"\font\code128.ttf");
                        using (Font font = new Font(privateFont.Families[0], it.Height))
                        {
                            using (SolidBrush drawBrush = new SolidBrush(Color.Black))
                            {
                                // DrawRotatedTextAt(g, it.Angle, it.Text, (int)drawPoint.X, (int)drawPoint.Y, font, drawBrush);
                                TRACE.Log("Font128 Barcode = " + it.Text);
                                g.DrawString(it.Text, font, drawBrush, drawPoint);
                            }
                        }
                    }
                   
                    privateFont.Families[0].Dispose();
                    privateFont.Dispose();
                }
                else
                {
                    var value = it.Text;
                    if (string.IsNullOrEmpty(value))
                        value = "12345678";

                    if (it.code39 == 0)
                    {
                        var bmp = Generate2(BarcodeFormat.CODE_39, value, it.Width, it.Height, it.Padding);
                        if (it.Angle == 90)
                            bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        else if (it.Angle == 180)
                            bmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        else if (it.Angle == 270)
                            bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        g.DrawImage(bmp, it.Location.X, it.Location.Y);
                        bmp.Dispose();
                    }
                    else
                    {
                        var bmp = Generate2(BarcodeFormat.CODE_128, value, it.Width, it.Height, it.Padding);

                        if (it.Angle == 90)
                            bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        else if (it.Angle == 180)
                            bmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        else if (it.Angle == 270)
                            bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);

                        g.DrawImage(bmp, it.Location.X, it.Location.Y);
                        bmp.Dispose();
                    }
                }
          
            }

        }
        private Image RotateImage(Image img)
        {
            int direction = 180; //회전각도

            //회전한 이미지 저장용 Bitmap 객체 생성
            Bitmap rimg = new Bitmap(img.Width, img.Height);
            Graphics GFX = Graphics.FromImage(rimg);

            //이미지 중심을 기준으로 회전
            Matrix matrix = new Matrix();
            Point center = new Point((int)img.Width / 2, (int)img.Height / 2);
            matrix.RotateAt(direction, center);

            GFX.Transform = matrix;
            GFX.Clear(Color.Transparent);
            GFX.DrawImage(img, new Point(0, 0));  //회전시킨 Graphics 객체에 원본 이미지 투하..
            GFX.Dispose();

            return rimg;
        }
        private void RoateImage( Graphics g, Bitmap src, Point point, float angle)
        {
            GraphicsState state = g.Save();
            g.ResetTransform();

            Bitmap trg = new Bitmap(src.Width, src.Height);
     //      Graphics g = Graphics.FromImage(trg); // 이미지 중심을 (0,0)으로 이동 
            g.TranslateTransform( src.Width / 2,src.Height / 2); // 회전 
            g.RotateTransform(angle); // 이미지 중심 원래 자표로 이동 
            g.TranslateTransform(-src.Width / 2, -src.Height / 2); // 원본 이미지로 그리기
            g.DrawImage(src, point);
            g.Restore(state);
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {


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
            listViewControl.Items.Clear();
            foreach( Control it in canvas1.Controls )
            {
                if (it.Tag != null)
                {
                    if (it.Tag.ToString() == "0")
                    {
                        var item = new ListViewItem(it.Name);
                        item.SubItems.Add("Text");
                        item.Tag = ((RotatedLabel)it).Id;
                        listViewControl.Items.Add(item);
                    }
                    else if (it.Tag.ToString() == "1")
                    {
                        var item = new ListViewItem(it.Name);
                        item.SubItems.Add("QRCode");
                        item.Tag = ((QRCode)it).Id;
                        listViewControl.Items.Add(item);
                    }
                    else if ( it.Tag.ToString() == "3" )
                    {
                        var item = new ListViewItem(it.Name);
                        item.SubItems.Add("DateTime");
                        item.Tag = ((RotatedLabel)it).Id;
                        listViewControl.Items.Add(item);
                    }
                    else
                    {
                        var item = new ListViewItem(it.Name);
                        item.SubItems.Add("Barcode");
                        item.Tag = ((Barcode)it).Id;
                        listViewControl.Items.Add(item);
                    }
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
            m_paper.texts.Clear();
            m_paper.qrs.Clear();
            m_paper.barcodes.Clear();
            m_paper.dateTimes.Clear();

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
                text.Id = it.Id;
                text.Fix = it.Fix;
                text.Multile = it.Multiple;
                text.m_multiple = it.m_multple;
                text.IsArray = it.IsArray;
                text.Separator = it.Separator;
                m_paper.texts.Add(text);
            }
            foreach (var it in m_dataTimeList)
            {
                var text = new Text();
                text.key = it.Name;
                text.Id = it.Id;
                text.font_name = it.Font.Name;
                text.font_size = (int)it.Font.Size;
                text.rotation = PropUtil.GetAngleToIdx(it.Angle);
                text.datetime_type = it.m_dateTimeFormat;
                text.x = it.Location.X;
                text.y = it.Location.Y;
           
                m_paper.dateTimes.Add(text);
            }
            foreach ( var it in m_barcodeList )
            {
                var barcode = new data.Barcode();
                barcode.key = it.Name;
                barcode.Id = it.Id;
                barcode.x = it.Location.X;
                barcode.y = it.Location.Y;
                barcode.width = it.Width;
                barcode.height = it.Height;
                barcode.barcode39 = it.code39;
                barcode.Angle = it.Angle;
                barcode.Padding = it.Padding;
                barcode.font = it.font;
                barcode.Length = it.Length;
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
                qr.Id = it.Id;
                m_paper.qrs.Add(qr);
            }

            var jsonObject = JsonConvert.SerializeObject(m_paper);

            var form = new SetFileNameForm();
            form.OnApply = delegate (string fileName)
            {
                if (!Directory.Exists("data"))
                    Directory.CreateDirectory("data");
   
                if (File.Exists(@"data\" + fileName + ".json"))
                    File.Delete(@"data\" + fileName + ".json");
                using (var sw = new StreamWriter(@"data\"+fileName + ".json"))
                {
                    sw.Write(jsonObject);
                }
            };

            form.ShowDialog();
            Process.Start(@"data");
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            buttonClear_Click(null, null);
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
                listBoxPrinter.Items.Add(it);
            }
        }

        private void panel2_Scroll(object sender, ScrollEventArgs e)
        {
            panel2.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }
    

        private void listBoxCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            canvas1.Controls.Clear();
            RefreshListBox();
        }

        private void listBoxPrinter_DoubleClick(object sender, EventArgs e)
        {

        }
        private PropertyTextForm m_textForm;
        private PropertyDateTimeForm m_dateTimeForm;
        private PropertyBarcodeForm m_barcodeForm;
        private PropertyQRForm m_qrForm;

        private void listViewControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewControl.SelectedItems.Count <= 0)
                return;
            var selectedName = listViewControl.SelectedItems[0].SubItems[0].Text;
            var type = listViewControl.SelectedItems[0].SubItems[1].Text;
            var tag = listViewControl.SelectedItems[0].Tag.ToString();
            foreach (Control it in canvas1.Controls)
            {
                if (type == "Text" &&  it is RotatedLabel && ((RotatedLabel)it).Id.ToString() == tag )
                {
                    if (m_textForm == null)
                    {
                        m_textForm = new PropertyTextForm();
                        m_textForm.SetLabel(it as RotatedLabel);
                        m_textForm.StartPosition = FormStartPosition.CenterScreen;
                        m_textForm.FormClosed += Form_FormClosed;
                        m_textForm.Show();
                    }
                }
                else if (type == "QRCode" && it is QRCode && ((QRCode)it).Id.ToString() == tag )
                {
                    if (m_qrForm == null)
                    {
                        m_qrForm = new PropertyQRForm();
                        m_qrForm.SetQR(it as QRCode);
                        m_qrForm.FormClosed += Form_FormClosed;
                        m_qrForm.Show();
                    }
                }
                else if (type == "Barcode" && it is Barcode && ((Barcode)it).Id.ToString() == tag )
                {
                    if (m_barcodeForm == null)
                    {
                        m_barcodeForm = new PropertyBarcodeForm();
                        m_barcodeForm.SetLabel(it as Barcode);
                        m_barcodeForm.StartPosition = FormStartPosition.CenterScreen;
                        m_barcodeForm.FormClosed += Form_FormClosed;
                        m_barcodeForm.Show();
                    }
                }
                else if (type == "DateTime" &&  it is RotatedLabel && ((RotatedLabel)it).Id.ToString() == tag )
                {
                    if (m_dateTimeForm == null)
                    {
                        m_dateTimeForm = new PropertyDateTimeForm();
                        m_dateTimeForm.SetLabel(it as RotatedLabel);
                        m_dateTimeForm.StartPosition = FormStartPosition.CenterScreen;
                        m_dateTimeForm.FormClosed += Form_FormClosed;
                        m_dateTimeForm.Show();
                    }
                }
            }
        }

        private void buttonEditJson_Click(object sender, EventArgs e)
        {
            var editJsonForm = new EditJsonForm();
            editJsonForm.Show();
        }

        private void buttonFixText_Click(object sender, EventArgs e)
        {

        }
    }
}
