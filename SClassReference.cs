using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeHelper
{
    class SClassReference
    {
        public static SClassReference Instance { get; set; }

        public Stages Stages { get; set; }

        public ScreenInfo ScreenInfo => _screenInfo ??= new ScreenInfo();

        private ScreenInfo _screenInfo;
    }
}
