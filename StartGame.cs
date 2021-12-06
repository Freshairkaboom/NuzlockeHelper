using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeHelper
{
    public class StartGame : Command
    {

        public StartGame() : base("startgame")
        {

        }

        public override void RunCommand() 
        {
            SManager.Stages.ResetCurrentStage();
            SManager.Stages.IncreaseCurrentStage(true);
            SManager.ScreenInfo.ResetInfo();
            SManager.ScreenInfo.AddInfo(StageInfo.GetMessage(1));
        }
    }
}
