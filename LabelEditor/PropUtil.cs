    using DigitalProduction.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelEditor
{
    public static class PropUtil
    {
        public static int GetIdxToAngle(int idx)
        {
            if (idx == 0) return 0;
            else if (idx == 1) return 90;
            else if (idx == 2) return 180;
            else if (idx == 3) return 270;
            return 0;
        }
        public static int GetAngleToIdx( int angle )
        {
            if (angle == 0) return 0;
            else if (angle == 90) return 1;
            else if (angle == 180) return 2;
            else if (angle == 270) return 3;
            return 0;
        }

        
    }
}
