using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabelEditor
{
    public class SelectControl
    {
        private Control m_ctrl;
        private Graphics m_g;
        private Pen m_pen = new Pen(Brushes.Red, 2);
        public void SetControl( Control ctrl )
        {
            if ( m_g != null )
            {
                m_g.Dispose();
            }
            m_ctrl = ctrl;
            if (m_ctrl != null)
            {
                m_g = m_ctrl.CreateGraphics();
                m_ctrl.Paint += M_ctrl_Paint;
                OnDraw();
            }

        }

        private void M_ctrl_Paint(object sender, PaintEventArgs e)
        {
            var pt = new Point(m_ctrl.Location.X - 1, m_ctrl.Location.Y - 1);
            var size = new Size(m_ctrl.Width + 1, m_ctrl.Height + 1);
            e.Graphics.DrawRectangle(m_pen, new Rectangle(pt, size));
        }

        public void OnDraw()
        {
            //var pt = new Point(m_ctrl.Location.X - 1, m_ctrl.Location.Y - 1);
            //var size = new Size(m_ctrl.Width + 1, m_ctrl.Height + 1);
            //m_g.DrawRectangle(m_pen, new Rectangle(pt, size));
        }
    }
}
