using DigitalProduction.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
        private List<Label> m_labelList = new List<Label>();
        private List<PictureBox> m_barcodeList = new List<PictureBox>();

        public Form1()
        {
            InitializeComponent();
            CreateMyStatusBar();
            canvas1.MouseDown += PanelLabel_MouseDown;
            canvas1.MouseMove += PanelLabel_MouseMove;
            canvas1.MouseMove += panel2_MouseMove;
            canvas1.MouseUp += Canvas1_MouseUp;
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
                    form.Show();
                }
                else if (ctrl is BarcodeLabel)
                {
                    var form = new PropertyBarcodeForm();
                    form.SetLabel(ctrl as BarcodeLabel);
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.Show();
                }
                else if (ctrl is QRCode)
                {
                    var form = new PropertyQRForm();
                    form.SetQR(ctrl as QRCode);
                    form.Show();
                }
               
           }

                m_selectedCtrl = ctrl;
       //     panelParent.Invalidate();
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
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (!ConnectPrinter())
                return;
            for ( int i = 0; i < canvas1.Controls.Count; i++ )
            {
                var ctrl = canvas1.Controls[i];
                var tag = int.Parse(ctrl.Tag.ToString());
                if ( tag == 0 )
                {
                    var label = ctrl as RotatedLabel;
                    
                    BXLLApi.PrintTrueFont(label.Location.X, label.Location.Y, "맑은 고딕", (int)label.Font.Size < 14 ? 14 : (int)label.Font.Size, 2, false, label.Font.Bold, false, label.Text, false);
                }
                else if ( tag == 1 )
                {
                    var pb = ctrl as QRCode;
                    string QRCode_data = "QRCode sample test 123";
                    BXLLApi.PrintQRCode(pb.Location.X, pb.Location.Y, (int)SLCS_QRCODE_MODEL.QRMODEL_2, (int)SLCS_QRCODE_ECC_LEVEL.QRECCLEVEL_M, (int)SLCS_QRCODE_SIZE.QRSIZE_4, (int)SLCS_ROTATION.ROTATE_0, QRCode_data);

                }
                else if ( tag == 2 )
                {
                    var pb = ctrl as BarcodeLabel;
                    int multiplier = 1;
                    var txt = "1234567890";
                    BXLLApi.Print1DBarcode(pb.Location.X, pb.Location.Y, (int)SLCS_BARCODE.CODE39, 2 * multiplier, 1 * multiplier, 48 * multiplier, (int)SLCS_ROTATION.ROTATE_0, (int)SLCS_HRI.HRI_NOT_PRINT, txt);
                }
                
            }
            //	Print Command
            BXLLApi.Prints(1, 1);

            // Disconnect printer
            BXLLApi.DisconnectPrinter();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 2);
            e.Graphics.DrawLine(blackPen, new Point(100, 100), new Point(0, 100));
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

    }
}
