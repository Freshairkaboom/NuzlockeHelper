using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeHelper
{
    public class Route
    {
        public readonly int RouteNumber;
        public bool IsClosed { get; private set; }

        public Route(int routeNumber, bool isClosed)
        {
            RouteNumber = routeNumber;
            IsClosed = isClosed;
        }

        public void CloseRoute()
        {
            IsClosed = true;
        }

        public void OpenRoute()
        {
            IsClosed = false;
        }
    }
}
