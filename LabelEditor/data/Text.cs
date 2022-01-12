using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelEditor.data
{
    public class Text
    {
        public string key { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int font_size { get; set; }
        public string font_name { get; set; }
        public bool bold { get; set; }
        public int rotation { get; set; }
    }
}
