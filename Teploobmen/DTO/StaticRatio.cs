using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teploobmen.DTO
{
    public class StaticRatio
    {
        public static double ratio;

        public static void SetRatio(double k)
        {
            ratio = k;
        }
        public static double GetRatio()
        {
            return ratio;
        }
    }
}
