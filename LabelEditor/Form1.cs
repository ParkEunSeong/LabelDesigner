using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        public Form1()
        {
            InitializeComponent();
            CreateMyStatusBar();
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
    }
}
