using System;
using System.Threading.Tasks;

namespace NuzlockeHelper
{
    public class CloseRoute : Command
    {
        public Routes Routes { get; private set; }

        public CloseRoute() : base("closeroute")
        {
            Routes = new Routes();
        }

        public override void RunCommand()
        {
            var firstRoute = Routes.allRoutes[0].RouteNumber;
            var lastRoute = Routes.allRoutes[^1].RouteNumber;
             
            SManager.ScreenInfo.ResetInfo();

            SManager.ScreenInfo.AddInfo($"These are the routes you have already closed:");

            for (byte i = 0; i < Routes.allRoutes.Length; i++)
            {
                if (Routes.allRoutes[i].IsClosed)
                {
                    SManager.ScreenInfo.AddInfo($"Route {Routes.allRoutes[i].RouteNumber}");
                }
            }

            SManager.ScreenInfo.AddInfo(" ");

            SManager.ScreenInfo.AddInfo($"Which route would you like to close? {firstRoute}-{lastRoute}");

            SManager.ScreenInfo.PrintInfo();

            string command = Console.ReadLine();

            bool isInt = int.TryParse(command, out var route);

            if (isInt && route <= Routes.allRoutes.Length)
            {
                ConfirmChoice(route);
            }

            SManager.ScreenInfo.ResetInfo();
            SManager.ScreenInfo.AddInfo(StageInfo.Messages[SManager.Stages.CurrentStage]);
        }

        private void ConfirmChoice(int route)
        {
            Console.WriteLine($"You have elected to close route {route}, press Y to confirm.");
            var command = Console.ReadLine();

            if (command == null || command.ToLower() != "y" || Routes.allRoutes[route - 1].IsClosed) return;
            Routes.allRoutes[route-1].CloseRoute();
        }

        /*Methods related to saving Routes list info. */

        public async Task SaveRoutes(StoreData data)
        {
            await data.CheckIfNoRoutesStored(Routes);
        }
    }
}
