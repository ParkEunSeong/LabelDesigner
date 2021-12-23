using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public Form1()
        {
            InitializeComponent();
            CreateMyStatusBar();
        }
        public void Initalize( LabelConfiguration config )
        {
            m_config = config;
            labelWidth.Text = "Width : "+config.MM_SIZE.Width.ToString();
            labelHeight.Text = "Height : "+config.MM_SIZE.Height.ToString();
            panelLabel.Width = config.PAPER_SIZE.Width;
            panelLabel.Height = config.PAPER_SIZE.Height;
            panelLabel.Region = Region.FromHrgn(CreateRoundRectRgn(2, 2, panelLabel.Width, panelLabel.Height, 20, 20));
            panelLabel.Location = new Point(100,100);
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

        private void panel2_Paint(object sender, PaintEventArgs e)
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
            var g = e.Graphics;
            g.DrawString("Hello World", new Font("맑은 고딕", 12), Brushes.Black, new Point());
        }
    }
}
