using DigitalProduction.Forms;
using LabelEditor.data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
        private LabelConfiguration m_config;
        private bool m_isDrag;
        private Point m_startPoint;
        private Control m_selectedCtrl;
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
        private List<BarcodeLabel> m_barcodeList = new List<BarcodeLabel>();
        private List<QRCode> m_qrList = new List<QRCode>();

        public Form1()
        {
            InitializeComponent();
            CreateMyStatusBar();
            canvas1.MouseDown += PanelLabel_MouseDown;
            canvas1.MouseMove += PanelLabel_MouseMove;
            canvas1.MouseMove += panel2_MouseMove;
            canvas1.MouseUp += Canvas1_MouseUp;
        }
        public void SetLabelFrom( frmMain frm )
        {
            m_labelSetForm = frm;
            StringBuilder strVersion = new StringBuilder(256);
            if (BXLLApi.GetDllVersion(strVersion))
                Text = "LabelDesigner AppVersion v1.0.0 DLL Version " + strVersion.ToString();
            else
                Text = "LabelDesigner Unknown";
        }

        private void Canvas1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void PanelLabel_MouseMove(object sender, MouseEventArgs e)
        {
           
            if (e.Button == MouseButtons.Left)
            {
                var pt = e.Location;

                if (IntersectRect(e.Location))
                {
                
                }
            }
        }

        private void PanelLabel_MouseDown(object sender, MouseEventArgs e)
        {
       
            if (e.Button == MouseButtons.Left)
            {
                if (IntersectRect(e.Location))
                {
                
                }
            }
        }

        public void Initalize( LabelConfiguration config )
        {
            m_config = config;
            labelMMSize.Text = $"{config.MM_SIZE.Width}X{config.MM_SIZE.Height}";
            labelPixel.Text = $"{config.PAPER_SIZE.Width}X{config.PAPER_SIZE.Height}";
            labelinch.Text = $"{config.INCH_SIZE.Width}X{config.INCH_SIZE.Height}";
            canvas1.Width = config.PAPER_SIZE.Width;
            canvas1.Height = config.PAPER_SIZE.Height;
            
            if ( config.BORDER == ContentData.LabelBorder.ELLIPSE )
                canvas1.Region = Region.FromHrgn(CreateRoundRectRgn(20, 20, canvas1.Width, canvas1.Height, 20, 20));
            canvas1.Location = new Point(100,100);

        }
        public void Refresh(LabelConfiguration config)
        {
            Initalize(config);
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
            m_statusBarPanel1.Text = $"mm:{Math.Truncate(e.X/2.8f)},{Math.Truncate(e.Y/2.8f)}";
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
                label.MouseDown += Label_MouseDown;
                label.MouseMove += Label_MouseMove;
                label.MouseUp += Label_MouseUp;
                label.Tag = 0;
                canvas1.Controls.Add(label);
                m_labelList.Add(label);
                listBoxCtrl.Items.Add(label.Name);
            }
            else if (tag.ToString() == "1")
            {
                var pb = new QRCode();
                pb.Name = "qrcode" + canvas1.Controls.Count;
                pb.Image = Image.FromFile("qr.png");
                pb.Width = 50;
                pb.Height = 50;
                pb.Location = new Point(100, 100);
                pb.MouseDown += Label_MouseDown;
                pb.MouseMove += Label_MouseMove;
                pb.MouseUp += Label_MouseUp;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Tag = 1;
                canvas1.Controls.Add(pb);
                m_qrList.Add(pb);
                listBoxCtrl.Items.Add(pb.Name);
            }
            else
            {
                var pb = new BarcodeLabel();
                 pb.Name = "barcode" + canvas1.Controls.Count;
                pb.Font = new Font("Code 128", 14);
                pb.Location = new Point(100, 100);
                pb.MouseDown += Label_MouseDown;
                pb.MouseMove += Label_MouseMove;
            
                pb.MouseUp += Label_MouseUp;
                pb.Tag = 2;
                canvas1.Controls.Add(pb);
                m_barcodeList.Add(pb);
                listBoxCtrl.Items.Add(pb.Name);
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
                else if (ctrl is BarcodeLabel)
                {
                    var form = new PropertyBarcodeForm();
                    form.SetLabel(ctrl as BarcodeLabel);
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

            //textBoxName.Text = ctrl.Name;
            //textBoxX.Text = ctrl.Location.X.ToString();
            //textBoxY.Text = ctrl.Location.Y.ToString();
            //textBoxWidth.Text = ctrl.Width.ToString();
            //textBoxHeight.Text = ctrl.Height.ToString();
            //if ( ctrl is Label )
            //{
            //    textBoxFontSize.Text = ((Label)ctrl).Font.Size.ToString();
            //    textBoxFontName.Text = ((Label)ctrl).Font.FontFamily.Name;
            //    checkBoxBold.Checked = ((Label)ctrl).Font.Style == FontStyle.Bold ? true : false;
            //}
            //else if ( ctrl is PictureBox )
            //{
                
            //}

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

        }

        private void listBoxCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panelLabel_Paint(object sender, PaintEventArgs e)
        {
        

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

        private void textBoxFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                m_selectedCtrl.Font = fontDialog1.Font;
                SetSelectedControl(m_selectedCtrl);
            }
        }

        private void textBoxX_TextChanged(object sender, EventArgs e)
        {

        }
        public const int ISerial = 0;
        public const int IParallel = 1;
        public const int IUsb = 2;
        public const int ILan = 3;
        public const int IBluetooth = 5;
        private string GetStatusMsg(int nStatus)
        {
            string errMsg = "";
            switch ((SLCS_ERROR_CODE)nStatus)
            {
                case SLCS_ERROR_CODE.ERR_CODE_NO_ERROR: errMsg = "No Error"; break;
                case SLCS_ERROR_CODE.ERR_CODE_NO_PAPER: errMsg = "Paper Empty"; break;
                case SLCS_ERROR_CODE.ERR_CODE_COVER_OPEN: errMsg = "Cover Open"; break;
                case SLCS_ERROR_CODE.ERR_CODE_CUTTER_JAM: errMsg = "Cutter jammed"; break;
                case SLCS_ERROR_CODE.ERR_CODE_TPH_OVER_HEAT: errMsg = "TPH overheat"; break;
                case SLCS_ERROR_CODE.ERR_CODE_AUTO_SENSING: errMsg = "Gap detection Error (Auto-sensing failure)"; break;
                case SLCS_ERROR_CODE.ERR_CODE_NO_RIBBON: errMsg = "Ribbon End"; break;
                case SLCS_ERROR_CODE.ERR_CODE_BOARD_OVER_HEAT: errMsg = "Board overheat"; break;
                case SLCS_ERROR_CODE.ERR_CODE_MOTOR_OVER_HEAT: errMsg = "Motor overheat"; break;
                case SLCS_ERROR_CODE.ERR_CODE_WAIT_LABEL_TAKEN: errMsg = "Waiting for the label to be taken"; break;
                case SLCS_ERROR_CODE.ERR_CODE_CONNECT: errMsg = "Port open error"; break;
                case SLCS_ERROR_CODE.ERR_CODE_GETNAME: errMsg = "Unknown (or Not supported) printer name"; break;
                case SLCS_ERROR_CODE.ERR_CODE_OFFLINE: errMsg = "Offline (The printer is in an error status)"; break;
                default: errMsg = "Unknown error"; break;
            }
            return errMsg;
        }

        private bool ConnectPrinter()
        {
            string strPort = "";
            int nInterface = ISerial;
            int nBaudrate = 115200, nDatabits = 8, nParity = 0, nStopbits = 0;
            int nStatus = (int)SLCS_ERROR_CODE.ERR_CODE_NO_ERROR;



            // USB
            nInterface = IUsb;
            nStatus = BXLLApi.ConnectPrinterEx(nInterface, strPort, nBaudrate, nDatabits, nParity, nStopbits);

            if (nStatus != (int)SLCS_ERROR_CODE.ERR_CODE_NO_ERROR)
            {
                BXLLApi.DisconnectPrinter();
                MessageBox.Show(GetStatusMsg(nStatus));
                return false;
            }
            return true;
        }
        private void SendPrinterSettingCommand(LabelConfiguration configuration)
        {
            // 203 DPI : 1mm is about 7.99 dots
            // 300 DPI : 1mm is about 11.81 dots
            // 600 DPI : 1mm is about 23.62 dots
            int dotsPer1mm = (int)Math.Round((float)BXLLApi.GetPrinterDPI() / 25.4f);
            int nPaper_Width = configuration.PAPER_SIZE.Width;
            int nPaper_Height = configuration.PAPER_SIZE.Height;
            int nMarginX = configuration.Margin.X;
            int nMarginY = configuration.Margin.Y;
            int nSpeed = (int)SLCS_PRINT_SPEED.PRINTER_SETTING_SPEED;
            int nDensity = configuration.DENSITY;
            int nOrientation = (int)configuration.ORIENTATION;

            int nSensorType = (int)configuration.SEMSOR_TYPE;


            //	Clear Buffer of Printer
            BXLLApi.ClearBuffer();

            // Rewinder is only available for XT series printers (XT5-40, XT5-43, XT5-46)
            if (configuration.OPERATION == LabelConfiguration.OPERATION_MODE.REWINDER )
            {
                BXLLApi.PrintDirect("RWDy", true);
            }

            //	Set Label and Printer
            //BXLLApi.SetConfigOfPrinter(BXLLApi.SPEED_50, 17, BXLLApi.TOP, false, 0, true);
            var cut = configuration.OPERATION == LabelConfiguration.OPERATION_MODE.CUT;
            BXLLApi.SetConfigOfPrinter(nSpeed, nDensity, nOrientation, cut, 1, true);

            // Select international character set and code table.To
            BXLLApi.SetCharacterset((int)SLCS_INTERNATIONAL_CHARSET.ICS_USA, (int)SLCS_CODEPAGE.FCP_CP1252);

            /* 
                1 Inch : 25.4mm
                1 mm   :  7.99 Dots (XT5-40, SLP-TX400, SLP-DX420, SLP-DX220, SLP-DL410, SLP-T400, SLP-D420, SLP-D220, SRP-770/770II/770III)
                1 mm   :  7.99 Dots (SPP-L310, SPP-L410, SPP-L3000, SPP-L4000) 
                1 mm   :  7.99 Dots (XD3-40d, XD3-40t, XD5-40d, XD5-40t, XD5-40LCT)
                1 mm   : 11.81 Dots (XT5-43, SLP-TX403, SLP-DX423, SLP-DX223, SLP-DL413, SLP-T403, SLP-D423, SLP-D223)
                1 mm   : 11.81 Dots (XD5-43d, XD5-43t, XD5-43LCT)
                1 mm   : 23.62 Dots (XT5-46)
            */

            BXLLApi.SetPaper(nMarginX, nMarginY, nPaper_Width, nPaper_Height, nSensorType, 0, 2 * dotsPer1mm);

            // Direct thermal
            if (m_config.MEDIA == LabelConfiguration.MEDIA_TPYE.DirectThermal )
                BXLLApi.PrintDirect("STd", true);
            else // Thermal transfer
                BXLLApi.PrintDirect("STt", true);
        }
        private void buttonPrint_Click(object sender, EventArgs e)
        {
           
            if (!ConnectPrinter())
                return;
            SendPrinterSettingCommand(m_config);
            for ( int i = 0; i < canvas1.Controls.Count; i++ )
            {
                var ctrl = canvas1.Controls[i];
                var tag = int.Parse(ctrl.Tag.ToString());
                if ( tag == 0 )
                {
                    var label = ctrl as RotatedLabel;
                    
                    BXLLApi.PrintTrueFont(label.Location.X, label.Location.Y, "맑은 고딕", (int)label.Font.Size < 14 ? 14 : (int)label.Font.Size, PropUtil.GetAngleToIdx(label.Angle), false, label.Font.Bold, false, label.Text, false);
                }
                else if ( tag == 1 )
                {
                    var pb = ctrl as QRCode;
                    string QRCode_data = "QRCode sample test 123";
                    BXLLApi.PrintQRCode(pb.Location.X, pb.Location.Y, (int)pb.QR_MODEL, (int)pb.ECC_LEVEL, (int)pb.QR_SIZE, (int)pb.QR_ROTATION, pb.Name);

                }
                else if ( tag == 2 )
                {
                    var pb = ctrl as BarcodeLabel;
                    var txt = "1234567890";
                    
                    BXLLApi.Print1DBarcode(pb.Location.X, pb.Location.Y, pb.BARCODE_TYPE, pb.NARROW_BAR_WIDTH, pb.WIDE_BAR_WIDTH, pb.BARCODE_HEIGHT, (int)pb.ROTATON, (int)SLCS_HRI.HRI_NOT_PRINT, txt);
                }
                
            }
            //	Print Command
            BXLLApi.Prints(1, 1);

            // Disconnect printer
            BXLLApi.DisconnectPrinter();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

            Pen blackPen = new Pen(Color.Black, 1);
            var startPoint = new Point(100, 100);
            //Math.Truncate(e.X / 2.8f)}
            int w = m_config.PAPER_SIZE.Width;
            int h = m_config.PAPER_SIZE.Height;
            int row = (int)(w / 28f);
            int col = (int)(h / 28f);
           
            for ( int i = 0; i <= row; i++ )
            {
                int x = 100 + (i * 28);
                DrawText(e.Graphics, x-5, 75, i.ToString());
                e.Graphics.DrawLine(blackPen, new Point(x, 100), new Point(x, 90));
             
            }
            for (int i = 1; i <= col; i++)
            {
                int y = 100 + (i * 28);
                DrawText(e.Graphics, 75, y-5, i.ToString());
                e.Graphics.DrawLine(blackPen, new Point(100, y), new Point(90, y));

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
          g.DrawString(text, drawFont, drawBrush, x, y, drawFormat);
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
                listBoxCtrl.Items.Add(it.Name);
            }
        }

        private void comboBoxRotation_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int idx = comboBoxRotation.SelectedIndex;
            //if (idx <= 1)
            //{
            //  if ( m_selectedCtrl is RotatedLabel )
            //    {
            //        ((RotatedLabel)m_selectedCtrl).Angle = 0;
            //    }
            //}
            //else if (idx == 2)
            //{
            //    if (m_selectedCtrl is RotatedLabel)
            //    {
            //        ((RotatedLabel)m_selectedCtrl).Angle = 90;
            //    }
            //}
            //else if (idx == 3)
            //{
            //    if (m_selectedCtrl is RotatedLabel)
            //    {
            //        ((RotatedLabel)m_selectedCtrl).Angle = 180;
            //    }

            //}
            //else if (idx == 4)
            //{
            //    if (m_selectedCtrl is RotatedLabel)
            //    {
            //        ((RotatedLabel)m_selectedCtrl).Angle = 270;
            //    }
            //}
             
            //((RotatedLabel)m_selectedCtrl).Invalidate();
        }

        private void buttonLabelSetting_Click(object sender, EventArgs e)
        {
            m_labelSetForm.Visible = !m_labelSetForm.Visible;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Paper paper = new Paper();
            paper.density = m_config.DENSITY;
            paper.margin_x = m_config.Margin.X;
            paper.margin_y = m_config.Margin.Y;
            paper.media_type = (int)m_config.MEDIA;
            paper.mm_width = m_config.MM_SIZE.Width;
            paper.mm_height = m_config.MM_SIZE.Height;
            paper.operation_mode = (int)m_config.OPERATION;
            paper.orientation = (int)m_config.ORIENTATION;
            paper.sensor_type = (int)m_config.SEMSOR_TYPE;
            paper.speed = (int)m_config.PRINT_SPEED;

            paper.texts = new List<Text>();
            paper.qrs = new List<QR>();
            paper.barcodes = new List<Barcode>();
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
                paper.texts.Add(text);
            }
            foreach( var it in m_barcodeList )
            {
                var barcode = new Barcode();
                barcode.key = it.Name;
                barcode.x = it.Location.X;
                barcode.y = it.Location.Y;
                barcode.barcode_height = it.BARCODE_HEIGHT;
                barcode.narrow_bar_width = it.NARROW_BAR_WIDTH;
                barcode.wide_bar_width = it.WIDE_BAR_WIDTH;
                paper.barcodes.Add(barcode);
            }
            foreach(var it in m_qrList )
            {
                var qr = new QR();
                qr.key = it.Name;
                qr.qr_model = it.QR_MODEL;
                qr.qr_size = it.QR_SIZE;
                qr.rotation = it.QR_ROTATION;
                qr.ecc_level = it.ECC_LEVEL;
                qr.x = it.Location.X;
                qr.y = it.Location.Y;
                paper.qrs.Add(qr);
            }
            var jsonObject = JsonConvert.SerializeObject(paper);
            var form = new SetFileNameForm();
            form.OnApply = delegate (string fileName)
            {
                using (var sw = new StreamWriter(fileName + ".json"))
                {
                    sw.Write(jsonObject);
                }
            };

            form.ShowDialog();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            MessageBox.Show("준비중입니다.");
        }
    }
}
