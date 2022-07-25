
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
    public partial class FormPrint : Form
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
        private List<RotatedLabel> m_dateTimeList = new List<RotatedLabel>();
        private List<Barcode> m_barcodeList = new List<Barcode>();
        private List<QRCode> m_qrList = new List<QRCode>();
        private List<string> m_printerList = new List<string>();
        private Paper m_paper;
        private delegate void FromServerData(string json, string dir );
        private string m_selectedPrint;
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
        private string GetJsonStringValue( ref JObject jobj, string key)
        {
            try
            {
                return jobj[key].ToString();
            }
            catch (Exception ex)
            {
                TRACE.Log("key="+ key +","+ ex.ToString());
            }
            return "";
        }
        private int GetJsonIntValue(ref JObject jobj, string key)
        {
            try
            {
                return int.Parse(jobj[key].ToString());
            }
            catch (Exception ex)
            {
                TRACE.Log("key=" + key + "," + ex.ToString());
            }
            return 0;
        }
        private  Paper LoadPaper( string json )
        {
            var ret = new Paper();
            var j = JObject.Parse(json);
            ret.mm_width = GetJsonIntValue(ref j, "mm_width");
            ret.mm_height = GetJsonIntValue(ref j, "mm_height");
            ret.orientation = GetJsonIntValue(ref j, "orientation");
            //   ret.MM_SIZE =
            //  var mmSize = GetJsonIntValue()
            return ret;
        }
        public void OnFromServerData(string json, string dir )
        {
            if (InvokeRequired)
            {
                var func = new FromServerData(OnFromServerData);
                Invoke(func, new object[] { json, dir });
            }
            else
            {
                try
                {
                    var j = JObject.Parse(json);
                    TRACE.Log(j.ToString());    
                    m_selectedPrint = GetJsonStringValue(ref j, "prntNm");
                    var fileName = GetJsonStringValue(ref j, "mdfrType");
                    if ( string.IsNullOrEmpty(m_selectedPrint))
                    {
                        MessageBox.Show("프린터가 null");
                        return;
                    }
                    else if (string.IsNullOrEmpty(fileName))
                    {
                        MessageBox.Show("서식파일이 null");
                        return;
                    }


                    foreach (var it in j.Properties())
                    {
                        if (it.Name == "mdfrType")
                        {
                            TRACE.Log("mdfrType = " + fileName);
                            string path = "";
                            if (string.IsNullOrEmpty(dir))
                                path = $"data/{fileName}.json";
                            else
                                path = $"data/{dir}/{ fileName}.json";

                            TRACE.Log( Environment.CurrentDirectory + "\\" +  path);
                            if (File.Exists( path))
                            {
                                using (var sr = new StreamReader(Environment.CurrentDirectory + "\\" + path))
                                {
                                    var data = sr.ReadToEnd();
                                    try
                                    {
                                        m_paper = JsonConvert.DeserializeObject<Paper>(data);
                                        if (m_paper != null)
                                        {
                                            Initalize(m_paper);
                                            foreach (var jt in m_labelList)
                                            {
                                                if (jt.Multiple)
                                                {
                                                    jt.Text = "";
                                                    foreach (var kt in jt.m_multple )
                                                    {
                                                        if (kt.Fix)
                                                            kt.content = kt.key;
                                                        else
                                                            kt.content = GetJsonStringValue(ref j, kt.key);
                                                        TRACE.Log("kt.content = " + kt.content);
                                                        jt.Text += kt.content;
                                                    }
                                                }
                                                else
                                                {
                                                    if (jt.Fix == false)
                                                    {
                                                        jt.Text = GetJsonStringValue(ref j, jt.Name);
                                                        if (jt.Name == "spcmCnnr" || jt.Name.Contains("Arr"))
                                                        {
                                                            try
                                                            {
                                                                var jarr = j[jt.Name].ToArray();
                                                                jt.Text = " ";
                                                                foreach (var kt in jarr)
                                                                {
                                                                    jt.Text += kt + "/";
                                                                }

                                                                if (jt.Text.Length > 1 && jt.Text[jt.Text.Length - 1] == '/')
                                                                {
                                                                    jt.Text = jt.Text.Substring(0, jt.Text.Length - 1);
                                                                }
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                TRACE.Log(ex.ToString());
                                                            }


                                                        }
                                                    }
                                                }
                                                TRACE.Log("text name = " + jt.Name + ", text = " + jt.Text + ", fix = " + jt.Fix  + ", array = " + jt.IsArray + ", gubun = " + jt.Separator );

                                            }
                                            foreach (var jt in m_dateTimeList)
                                            {
                                                jt.Text = GetJsonStringValue(ref j, jt.Name);
                                                TRACE.Log("datetime name = " + jt.Name + ", text = " + jt.Text);
                                            }
                                            foreach (var jt in m_qrList)
                                            {
                                                jt.Text = GetJsonStringValue(ref j, jt.Name);
                                                TRACE.Log("qr name = " + jt.Name + ", text = " + jt.Text);
                                            }
                                            foreach (var jt in m_barcodeList)
                                            {
                                                jt.Text = GetJsonStringValue(ref j, jt.Name);
                                                TRACE.Log("barcode name = " + jt.Name + ", text = " + jt.Text);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Paper is null.", "알림");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("불러온 데이터 파일에 형식 오류가 있습니다." + ex.ToString(), "알림");
                                    }
                                }
                            }
                            else
                            {
                                TRACE.Log("서식 파일이 존재하지 않습니다.");
                             //   Close();
                                return;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    TRACE.Log(ex.ToString());
                }
                TRACE.Log("print");
                Print();
            }
        }
        public void Print()
        {
            TRACE.Log("Print()");
            Visible = false;
            m_printButton = false;
            if (Config.PRINT == "BXL")
            {
                TRACE.Log("BXL Print");
                BXLConfiguration config = new BXLConfiguration();
                config.density = m_paper.density;
                config.height = m_paper.bxl_height;
                config.width = m_paper.bxl_width;
                config.speed = m_paper.speed;
                config.sensor_type = m_paper.sensor_type;
                config.orientation = m_paper.orientation;
                config.margin_x = m_paper.margin_x;
                config.margin_y = m_paper.margin_y;
                TRACE.Log($"BXL density={config.density},height={config.height}," +
                    $"width={config.width},speed={config.speed}," +
                    $"sensor_type={config.sensor_type},orientation={config.orientation}" +
                    $"marinX={config.margin_x},marginY={config.margin_y}");
                var bxl = new BXLPrint();
                bxl.OnEndPrint = delegate ()
                {
                    //Close();
                };
                bxl.Initalize(config, m_paper, m_labelList, m_dateTimeList, m_barcodeList, m_qrList);
                
            }
            else
            {
                buttonPrint_Click(null, null);
            }
         //   Close();
        }
        public FormPrint()
        {

            InitializeComponent();
            //Visible = false;
            CreateMyStatusBar();
            FormClosed += Form1_FormClosed;
         
            foreach ( string it in PrinterSettings.InstalledPrinters)
            {
                m_printerList.Add(it);
            }
            var a = PixelToCentimeter(2480);

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
         //   m_bQuit = true;
         //   if (m_labelSetForm != null )
         //       m_labelSetForm.Close();
        //    timer1.Stop();
         //   if ( m_netCient != null )
         //       m_netCient.Close();
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

            TRACE.Log("texts");
            for ( int i = 0; i < paper.texts.Count; i++ )
            {
                var label = new RotatedLabel();
                label.AutoSize = true;
                label.Name = paper.texts[i].key;
                label.Location = new Point(paper.texts[i].x, paper.texts[i].y);
                label.Font = new Font(paper.texts[i].font_name, paper.texts[i].font_size, paper.texts[i].bold ? FontStyle.Bold : FontStyle.Regular);
                label.Angle = PropUtil.GetIdxToAngle(paper.texts[i].rotation);
                label.Text = label.Name;
                label.Tag = 0;
                label.Fix = paper.texts[i].Fix;
                label.Multiple = paper.texts[i].Multile;
                label.IsArray = paper.texts[i].IsArray;
                label.Separator = paper.texts[i].Separator;
                foreach(var it in paper.texts[i].m_multiple )
                {
                    label.m_multple.Add(new data.Text(it.key, it.Fix));
                }
                label.Selected();
                canvas1.Controls.Add(label);
                listBoxCtrl.Items.Add(label.Name + "-Text");
                m_labelList.Add(label );

            }
            TRACE.Log("datetimes");
            for (int i = 0; i < paper.dateTimes.Count; i++)
            {
                var label = new RotatedLabel();
                label.AutoSize = true;
                label.Name = paper.dateTimes[i].key;
                label.Location = new Point(paper.dateTimes[i].x, paper.dateTimes[i].y);
                label.Font = new Font(paper.dateTimes[i].font_name, paper.dateTimes[i].font_size, paper.dateTimes[i].bold ? FontStyle.Bold : FontStyle.Regular);
                label.Angle = PropUtil.GetIdxToAngle(paper.dateTimes[i].rotation);
                label.Text = label.Name;
                label.Tag = 3;
                label.Selected();
                label.m_dateTimeFormat = paper.dateTimes[i].datetime_type;
                canvas1.Controls.Add(label);
                listBoxCtrl.Items.Add(label.Name + "-DateTime");
                m_dateTimeList.Add(label);

            }
            TRACE.Log("qrs");
            for (int i = 0; i < paper.qrs.Count; i++ )
            {
                var pb = new QRCode();
                pb.Name = paper.qrs[i].key;
                pb.Image = Image.FromFile("qr.png");
                pb.Width = paper.qrs[i].width;
                pb.Height =  paper.qrs[i].height;
                pb.Text = pb.Name;
                pb.Location = new Point(paper.qrs[i].x, paper.qrs[i].y);
                
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Tag = 1;
                canvas1.Controls.Add(pb);
                m_qrList.Add(pb);
                listBoxCtrl.Items.Add(pb.Name + "-QRCode");
            }
            TRACE.Log("barcodes");
            for ( int i = 0; i < paper.barcodes.Count; i++ )
            {
                try
                {
                    var pb = new Barcode();
                    Image img = null;
                    pb.Name = paper.barcodes[i].key;
                    pb.Angle = paper.barcodes[i].Angle;
                    if (paper.barcodes[i].barcode39 == 0)
                    {
                        pb.code39 = 0;
                        Barcode39 barcode39 = new Barcode39();
                        barcode39.Code = "12345678";
                        barcode39.BarHeight = paper.barcodes[i].height;
                        img = barcode39.CreateDrawingImage(Color.Black, Color.White);
                    }
                    else
                    {
                        pb.code39 = 1;
                        Barcode128 barcode128 = new Barcode128();
                        barcode128.Code = "12345678";
                        barcode128.BarHeight = paper.barcodes[i].height;
                        img = barcode128.CreateDrawingImage(Color.Black, Color.White);
                    }
                    pb.font = paper.barcodes[i].font;
                    pb.Image = img;
                    pb.Location = new Point(paper.barcodes[i].x, paper.barcodes[i].y);
                    pb.Width = paper.barcodes[i].width;
                    pb.Height = paper.barcodes[i].height;
                    pb.Padding = paper.barcodes[i].Padding;
                    pb.Length = paper.barcodes[i].Length;
                    pb.Tag = 2;
                    canvas1.Controls.Add(pb);
                    m_barcodeList.Add(pb);
                    listBoxCtrl.Items.Add(pb.Name + "-Barcode");
                }
                catch(Exception ex)
                {
                    TRACE.Log(ex.ToString());

                }
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
       
        }


        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
        private void Form1_Load(object sender, EventArgs e)
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
            foreach (string it in PrinterSettings.InstalledPrinters)
            {
                if ( it == m_selectedPrint )
                {
                    TRACE.Log("installed printer");
                }
            }
                TRACE.Log("PrintName = " + m_selectedPrint);
            doc.PrinterSettings.PrinterName = m_selectedPrint;

            //doc.OriginAtMargins
            //     doc.PrinterSettings.PrintRange = PrintRange.Selection;
            //doc.PrinterSettings.FromPage = 0;
            //doc.PrinterSettings.ToPage = 1;
            doc.PrintPage += Doc_PrintPage;
            doc.EndPrint += Doc_EndPrint;
            if ( sender != null )
                m_printButton = true;
            TRACE.Log("출력");
            doc.Print();
        }

        private void Doc_EndPrint(object sender, PrintEventArgs e)
        {
            if (m_printButton)
            {
                Initalize(m_paper);
            }
        }
        private void DrawRotatedTextAt(Graphics gr, float angle, string txt, int x, int y, Font the_font, Brush the_brush)
        {
            // Save the graphics state.
            GraphicsState state = gr.Save();
            gr.ResetTransform();

            // Rotate.
            gr.RotateTransform(angle);

            // Translate to desired position. Be sure to append
            // the rotation so it occurs after the rotation.
            gr.TranslateTransform(x, y, MatrixOrder.Append);

            // Draw the text at the origin.
            gr.DrawString(txt, the_font, the_brush, 0, 0);

            // Restore the graphics state.
            gr.Restore(state);
        }
        public static Bitmap RotateImage(Image image, PointF offset, float angle)
        {
            Bitmap trg = new Bitmap(image.Width, image.Height);
            Graphics g = Graphics.FromImage(trg); // 이미지 중심을 (0,0)으로 이동
            g.TranslateTransform(image.Width / 2, image.Height / 2); // 회전 
            g.RotateTransform(angle); // 이미지 중심 원래 자표로 이동 
            g.TranslateTransform(-image.Width / 2, -image.Height / 2); // 원본 이미지로 그리기 
            g.DrawImage(image, new Point(0, 0));
            return trg;
        }
        private void DrawRotatedImage(Graphics gr, Image img, float angle, string txt, int x, int y, int w, int h)
        {
            Bitmap trg = new Bitmap(img.Width, img.Height);
            // Save the graphics state.
            GraphicsState state = gr.Save();

            gr.ResetTransform();

            // Rotate.
            gr.RotateTransform(angle);

            // Translate to desired position. Be sure to append
            // the rotation so it occurs after the rotation.
            gr.TranslateTransform(x, y, MatrixOrder.Append);

            // Draw the text at the origin.
            gr.DrawImage(img, x, y, w, h);

            // Restore the graphics state.
            gr.Restore(state);
        }
        public string ParseStrDateTime(string text, int s, int e)
        {
            try
            {
                return text.Substring(s, e);
            }
            catch (Exception ex)
            {
                TRACE.Log(text + ", " + s + "," + e + "," + ex.ToString());

            }
            return "";
        }
        public string ConvertDateTime(string text, int format)
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
            else if (format == 2)
            {
                if (!string.IsNullOrEmpty(hour))
                    return $"{year}-{month}-{day} {hour}:{min}";
                else
                    return $"{year}-{month}-{day}";
            }
            else if (format == 3)
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
        public static Bitmap Generate2(BarcodeFormat format, string text, int width, int height, int padding)
        {
            BarcodeWriter writer = new BarcodeWriter();
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
        public string ReturnCode128(string text)
        {
            const int codetype = 105;
            string textcode = text.Trim();
            int quantidade = textcode.Length;
            int[] arrayintcode = new int[quantidade];

            for (int i = 0; i < quantidade; i++)
            {
                char valToConvertToASCII = Convert.ToChar(textcode[i]);
                int valToMultiply = valToConvertToASCII - 32;
                arrayintcode[i] = valToMultiply;
            }

            string[] codemulti = new string[quantidade + 3];
            codemulti[0] = codetype.ToString();
            for (int i = 1; i < quantidade + 1; i++)
            {
                codemulti[i] = (i * arrayintcode[i - 1]).ToString();
            }

            int value = 0;
            for (int i = 0; i < codemulti.Count(); i++)
            {
                value += Convert.ToInt32(codemulti[i]);
            }

            int module = value % codetype;

            char charverify = (char)(module + 32);

            char start = (char)186;
            char stop = (char)186;

            return $"{start}{textcode}{charverify}{stop}";
        }
        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (var it in m_labelList)
            {

                PointF drawPoint = new PointF(it.Location.X, it.Location.Y); // 좌측 상단 시작점. // 2중 using 문 사용.
                if (it.Fix)
                    it.Text = it.Name;
                else if (string.IsNullOrEmpty(it.Text))
                    continue;
                TRACE.Log("Text=" + it.Text + "," + it.Location.X + "," + it.Location.Y);
                Font font = it.Font;
                using (SolidBrush drawBrush = new SolidBrush(Color.Black))
                {
                    DrawRotatedTextAt(g, it.Angle, it.Text, (int)drawPoint.X, (int)drawPoint.Y, font, drawBrush);
                    //   g.DrawString(it.Text, font, drawBrush, drawPoint);
                }

            }

            foreach (var it in m_dateTimeList)
            {
                if (string.IsNullOrEmpty(it.Text))
                    continue;
                PointF drawPoint = new PointF(it.Location.X, it.Location.Y); // 좌측 상단 시작점. // 2중 using 문 사용.
                Font font = it.Font;
              
                    using (SolidBrush drawBrush = new SolidBrush(Color.Black))
                    {
                        //if (string.IsNullOrEmpty(it.Text) || !string.IsNullOrEmpty(it.Text) && it.Text.Contains("datetime"))
                       //     it.Text = DateTime.Now.ToString("yyyyMMddHHmm");
                        var str = ConvertDateTime(it.Text, it.m_dateTimeFormat);
                        TRACE.Log($"dateTime {it.Text}, {it.Anchor}, {str}, {it.m_dateTimeFormat}");
                        DrawRotatedTextAt(g, it.Angle, str, (int)drawPoint.X, (int)drawPoint.Y, font, drawBrush);
                        it.Text = it.Name;
                        //g.DrawString(it.Text, font, drawBrush, 0, 0);

                    }
                
            }
            foreach ( var it in m_qrList )
            {
                string strQRCode = it.Text;
                if (!string.IsNullOrEmpty(strQRCode))
                {
                    ZXing.BarcodeWriter barcodeWriter = new ZXing.BarcodeWriter();
                    barcodeWriter.Format = ZXing.BarcodeFormat.QR_CODE;

                    barcodeWriter.Options.Width = it.Width;
                    barcodeWriter.Options.Height = it.Height;


                    Image img = barcodeWriter.Write(strQRCode);
                    g.DrawImage(img, it.Location.X, it.Location.Y, it.Width, it.Height);
                    TRACE.Log("QR=" + it.Text + "," + it.Location.X + "," + it.Location.Y + ", " + it.Width + "," + it.Height);
                    img.Dispose();
                }
            }
            foreach (var it in m_barcodeList)
            {
                if (string.IsNullOrEmpty(it.Text))
                    continue;

                if (it.Length > 0)
                    it.Text = it.Text.PadLeft(it.Length, '0');
                TRACE.Log("length = " + it.Length);
                if (it.font)
                {
                    PrivateFontCollection privateFont = new PrivateFontCollection();
                    PointF drawPoint = new PointF(it.Location.X, it.Location.Y); // 좌측 상단 시작점. // 2중 using 문 사용.

                    if (it.code39 == 0)
                    {
                        it.Text = "*" + it.Text + "*";
                        privateFont.AddFontFile(Environment.CurrentDirectory + @"\font\code39.ttf");
                    }
                    else
                    {
                        privateFont.AddFontFile(Environment.CurrentDirectory + @"\font\code128.ttf");
                        BARCODE_LABEL.BARCODE bc = new BARCODE_LABEL.BARCODE();
                        var err = "";
                         it.Text = bc.CODE128(it.Text, "B", ref err);
                        //it.Text = ReturnCode128(it.Text);
                        if ( !string.IsNullOrEmpty(err))
                            TRACE.Log("barcode 128 ttf error = " + err);
                    }
                    TRACE.Log("Barcode Text=" + it.Text + "," + it.Location.X + "," + it.Location.Y);
                    using (Font font = new Font(privateFont.Families[0], it.Height))
                    {
                        using (SolidBrush drawBrush = new SolidBrush(Color.Black))
                        {
                            // DrawRotatedTextAt(g, it.Angle, it.Text, (int)drawPoint.X, (int)drawPoint.Y, font, drawBrush);
                            g.DrawString(it.Text, font, drawBrush, drawPoint);
                        }
                    }
                    privateFont.Families[0].Dispose();
                    privateFont.Dispose();
                }
                else
                {
                    var value = it.Text;
                 
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


    }
}
