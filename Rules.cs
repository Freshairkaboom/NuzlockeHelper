using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeHelper
{
    public class Rules : Command
    {
        public List<string> FinalRules = new();

        public Rules() : base("rules")
        { 
            /*The first core rules are always added, otherwise it's not a Nuzlocke run. */
            FinalRules.Add(RulesDictionary.CoreRuleDescriptions[0]);
            FinalRules.Add(RulesDictionary.CoreRuleDescriptions[1]);
        }

        public void AddRule(string rule)
        {
            FinalRules.Add(rule);
        }

        public override void RunCommand()
        {
            SManager.ScreenInfo.ResetInfo();
            SManager.ScreenInfo.AddInfo("These are the rules you have chosen for this playthrough:");
            SManager.ScreenInfo.AddInfo(FinalRules);
            SManager.ScreenInfo.AddInfo(" ");
            SManager.ScreenInfo.AddInfo("Type \"return\" to go back to the playthrough menu.");
            SManager.ScreenInfo.PrintInfo();

            string command = Console.ReadLine();

            if (command.ToLower() == "return")
            {
                SManager.ScreenInfo.ResetInfo();
                SManager.ScreenInfo.AddInfo(StageInfo.GetMessage(SManager.Stages.CurrentStage));
                return;
            }
            else RunCommand();
        }
    }
}
