using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelEditor
{
    public class LabelConfiguration
    {
      
        public LabelConfiguration()
        {

        }
        public static int DPI = 101;
        public static int dotsPer1mm = (int)Math.Round((float)300 / 25.4f);
        public Size MM_SIZE { get; set; }
        public Size PAPER_SIZE
        {
            get
            {
                float w = MM_SIZE.Width;
                w /= 25.4f;
                w *= DPI;
                float h = MM_SIZE.Height;
                h /= 25.4f;
                h *= DPI;
                var size = new Size((int)w, (int)h);
                return size;
            }
        }
        public Size INCH_SIZE
        {
            get
            {
                return new Size((int)(MM_SIZE.Width / 25.4f), (int)(MM_SIZE.Height / 25.4f));
            }
        }
        public PageSettings PAGE_SETTINGS { get; set; }
        
        

    }
}
