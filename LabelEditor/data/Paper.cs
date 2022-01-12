using System;
using System.Collections.Generic;
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
        public int orientation { get; set; }
        public int media_type { get; set; }
        public int sensor_type { get; set; }
        public int operation_mode { get; set; }
        public int speed { get; set; }
        public int density { get; set; }

        
        public List<Barcode> barcodes{get;set;}
        public List<Text> texts { get; set; }
        public List<QR> qrs { get; set; }

    }
}
