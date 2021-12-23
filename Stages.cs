using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NuzlockeHelper.SManager;

namespace NuzlockeHelper
{
    public class Stages
    {

        public byte CurrentStage { get; private set; }

        public byte EndStage { get; private set; }

        public Stages(byte _CurrentStage, byte _EndStage)
        {
            SClassReference.Instance.Stages = this;
            CurrentStage = _CurrentStage;
            EndStage = _EndStage;
        }

        public void ResetCurrentStage()
        {
            CurrentStage = 0;
        }
             
        public bool IncreaseCurrentStage(bool isRunning)
        {
            CurrentStage++;

            if (CurrentStage == EndStage)
            {
                CurrentStage = 0;
                isRunning = false;
            }

            return isRunning;
        }

        public bool ReduceCurrentStage(bool isRunning)
        {
            CurrentStage--;

            if (CurrentStage <= 0)
            {
                CurrentStage = 0;
                isRunning = false;
            }

            return isRunning;
        }

        public async Task SaveStages(StoreData data)
        {
            throw new NotImplementedException();
        }
    }
}
