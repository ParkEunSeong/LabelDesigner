using System;
using System.Collections.Generic;
using System.Drawing;
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
        private int dotsPer1mm = (int)Math.Round((float)BXLLApi.GetPrinterDPI() / 25.4f);
        public Size MM_SIZE { get; set; }
        public Size PAPER_SIZE
        {
            get
            {
                return new Size(MM_SIZE.Width * dotsPer1mm, MM_SIZE.Height * dotsPer1mm);
            }
        }
        public string FileName { get; set; }
        public Point Margin { get; set; }
        public SLCS_ORIENTATION ORIENTATION { get; set; }
        public SLCS_MEDIA_TYPE SEMSOR_TYPE { get; set; }
        public SLCS_PRINT_SPEED PRINT_SPEED { get; set; }
        public int DENSITY { get; set; }
        public ContentData.LabelBorder BORDER { get; set; }
    }
}
