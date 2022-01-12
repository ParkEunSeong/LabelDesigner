using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelEditor.data
{
    public class QR
    {
        public string key { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int ecc_level { get; set; }
        public int qr_model { get; set; }
        public int rotation { get; set; }
        public int qr_size { get; set; }
    }
}
