using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelEditor.data
{
    public class Paper
    {
        public int mm_width { get; set; }
        public int mm_height { get; set; }
        public int margin_x { get; set; }
        public int margin_y { get; set; }

        public int bxl_width { get; set; }
        public int bxl_height { get; set; }
        public int speed { get; set; }
        public int density { get; set; }
        public int sensor_type { get; set; }
        /// <summary>
        /// 0 = vertical, 1 = horizontal 
        /// </summary>!
        public int orientation { get; set; }

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
        public List<Barcode> barcodes { get; set; } = new List<Barcode>();
        public List<Text> texts { get; set; } = new List<Text>();
        public List<QR> qrs { get; set; } = new List<QR>();
        public List<Text> dateTimes { get; set; } = new List<Text>();

    }
}
