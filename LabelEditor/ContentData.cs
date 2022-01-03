using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelEditor
{
    public class ContentData
    {
        public enum Type
        {
            TEXT,
            QRCODE,
            BARCODE
        }
        public enum LabelBorder
        {
            RECTANGLE,
            ELLIPSE
        }

        public int x { get; set; }
        public int y { get; set; }
        public string key { get; set; }
        public Type type {get;set;}
        public string font_name { get; set; }
        public int font_size { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public LabelBorder label_border { get; set; }
    }
}
