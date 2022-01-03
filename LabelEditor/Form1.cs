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
            labelWidth.Text = "Width : "+config.MM_SIZE.Width.ToString();
            labelHeight.Text = "Height : "+config.MM_SIZE.Height.ToString();
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
            var label = new Label();
            label.Location = new Point(100, 100);
            canvas1.Controls.Add(label);
            
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

        private void textBoxWidth_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBoxHeight_TextChanged(object sender, EventArgs e)
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
            if ( fontDialog1.ShowDialog() == DialogResult.OK )
            {
                var name = fontDialog1.Font.Name;
                var size = fontDialog1.Font.Size;
                var bold = fontDialog1.Font.Bold;
            }
        }

        private void textBoxX_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
