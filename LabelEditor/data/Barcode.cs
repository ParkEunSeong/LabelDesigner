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
        public int width { get; set; }
        public int height { get; set; }
        public int Angle { get; set; }
        public int Padding { get; set; }
        public int Id { get; set; }
        /// <summary>
        /// 0 : 39, 1 : 128
        /// </summary>
        public int barcode39 { get; set; }
    }
}
