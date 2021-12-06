using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeHelper
{
    public class Routes
    {
        public Route[] allRoutes = new Route[25];

        public Routes()
        {
            for (int routeNR = 0; routeNR < 25; routeNR++)
            {
                
                allRoutes[routeNR] = new Route(routeNR+1, false);
            }
        }
    }

}
