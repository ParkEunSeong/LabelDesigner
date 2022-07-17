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
        public int width { get; set; }
        public int height { get; set; }
        public int Id { get; set; }
        
        public int bxl_qr_model { get; set; }
        public int bxl_ecc_level { get; set; }
        public int bxl_qr_size { get; set; }
        public int bxl_qr_rotation { get; set; }
    }
}
