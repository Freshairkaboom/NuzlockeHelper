using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeHelper
{
    public class CloseRoute : Command
    {
        public Routes _routes { get; private set; }

        public CloseRoute() : base("closeroute")
        {
            _routes = new Routes();
        }

        public override void RunCommand()
        {
            var firstRoute = _routes.allRoutes[0].RouteNumber;
            var lastRoute = _routes.allRoutes[^1].RouteNumber;
             
            SManager.ScreenInfo.ResetInfo();

            SManager.ScreenInfo.AddInfo($"These are the routes you have already closed:");

            for (byte i = 0; i < _routes.allRoutes.Length; i++)
            {
                if (_routes.allRoutes[i].IsClosed)
                {
                    SManager.ScreenInfo.AddInfo($"Route {_routes.allRoutes[i].RouteNumber}");
                }
            }

            SManager.ScreenInfo.AddInfo(" ");

            SManager.ScreenInfo.AddInfo($"Which route would you like to close? {firstRoute}-{lastRoute}");

            SManager.ScreenInfo.PrintInfo();

            string command = Console.ReadLine();

            bool isInt = int.TryParse(command, out var route);

            if (isInt && route <= _routes.allRoutes.Length)
            {
                ConfirmChoice(route);
            }

            SManager.ScreenInfo.ResetInfo();
            SManager.ScreenInfo.AddInfo(StageInfo.Messages[SManager.Stages.CurrentStage]);
        }

        private void ConfirmChoice(int route)
        {
            string command;
            Console.WriteLine($"You have elected to close route {route}, press Y to confirm.");
            command = Console.ReadLine();

            if (command.ToLower() == "y" && !_routes.allRoutes[route - 1].IsClosed)
            {
                _routes.allRoutes[route-1].CloseRoute();
                return;
            }
        }
    }
}
