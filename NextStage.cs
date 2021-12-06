using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NuzlockeHelper.SManager;

namespace NuzlockeHelper
{
    public class NextStage : Command
    {

        public NextStage() : base("nextstage")
        {

        }

        public override void RunCommand()
        {
            byte _nextKey = (byte) (SManager.Stages.CurrentStage + 1);

            SManager.Stages.IncreaseCurrentStage(true);
            SManager.ScreenInfo.ResetInfo();
            SManager.ScreenInfo.AddInfo(StageInfo.GetMessage(_nextKey));
        }
    }
}
