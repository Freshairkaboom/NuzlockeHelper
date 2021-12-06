using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeHelper
{
    /**Static singleton*/
    public static class SManager
    {
        public static Stages Stages => SClassReference.Instance.Stages;

        public static ScreenInfo ScreenInfo => SClassReference.Instance.ScreenInfo;
    }
}
