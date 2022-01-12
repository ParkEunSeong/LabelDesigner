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
        public enum OPERATION_MODE
        {
            TEAR_OFF,
            CUT,
            REWINDER
        }
        public enum MEDIA_TPYE
        {
            DirectThermal,
            ThermalTransfer
        }
        public LabelConfiguration()
        {

        }
        public static int dotsPer1mm = (int)Math.Round((float)BXLLApi.GetPrinterDPI() / 25.4f);
        public Size MM_SIZE { get; set; }
        public Size PAPER_SIZE
        {
            get
            {
                return new Size(MM_SIZE.Width * dotsPer1mm, MM_SIZE.Height * dotsPer1mm);
            }
        }
        public Size INCH_SIZE
        {
            get
            {
                return new Size((int)(MM_SIZE.Width / 25.4f), (int)(MM_SIZE.Height / 25.4f));
            }
        }
        public string FileName { get; set; }
        public Point Margin { get; set; }
        public SLCS_ORIENTATION ORIENTATION { get; set; }
        public SLCS_SENSOR_TYPE SEMSOR_TYPE { get; set; }
        public SLCS_PRINT_SPEED PRINT_SPEED { get; set; }
        public int DENSITY { get; set; }
        public OPERATION_MODE OPERATION { get; set; }
        public ContentData.LabelBorder BORDER { get; set; }
        public MEDIA_TPYE MEDIA { get; set; }

    }
}
