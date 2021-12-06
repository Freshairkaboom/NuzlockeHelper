using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeHelper
{
    public class PreviousStage : Command
    {

        public PreviousStage() : base("previousstage")
        {

        }

        public override void RunCommand()
        {
            byte _prevKey = (byte)(SManager.Stages.CurrentStage -1);

            SManager.Stages.ReduceCurrentStage(true);
            SManager.ScreenInfo.ResetInfo();
            SManager.ScreenInfo.AddInfo(StageInfo.GetMessage(_prevKey));
        }
    }
}
