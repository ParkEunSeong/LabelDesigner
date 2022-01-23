using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabelEditor
{
    public class Barcode : PictureBox
    {
        /// <summary>
        /// 1 : 39, 0 : 128
        /// </summary>
        public int code39 { get; set; }
    }
}
