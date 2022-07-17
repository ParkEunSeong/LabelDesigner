using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelEditor
{
    public class BXLConfiguration
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
     
        public int width { get; set; }
        public int height { get; set; }
        public int margin_x { get; set; }
        public int margin_y { get; set; }
        public int speed { get; set; }
        public int density { get; set; }
        public int orientation { get; set; }
        public int sensor_type { get; set; }

    }
}
