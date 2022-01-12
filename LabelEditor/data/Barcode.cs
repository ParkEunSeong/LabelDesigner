using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelEditor.data
{
    public class Barcode
    {
        public string key { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int narrow_bar_width { get; set; }
        public int barcode_height { get; set; }
        public int wide_bar_width { get; set; }
    }
}
