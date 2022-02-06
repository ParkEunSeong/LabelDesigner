using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabelEditor
{
    public class Barcode : PictureBox
    {
        /// <summary>
        /// 1 : 39, 0 : 128
        /// </summary>
        private bool m_selected;
        public int code39 { get; set; }
        public Barcode()
        {
            Paint += delegate (object sender, PaintEventArgs e)
            {
                if (m_selected)
                    e.Graphics.DrawRectangle(new Pen(Brushes.Red, 3), new Rectangle(0, 0, Width - 1, Height - 1));

            };

        }


        public void Selected()
        {
            m_selected = true;
            Invalidate();
        }
        public void UnSelected()
        {
            m_selected = false;
            Invalidate();
        }

    }
}
