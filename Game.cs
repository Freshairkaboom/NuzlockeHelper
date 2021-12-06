using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeHelper
{
    public class Game
    {

        public bool IsRunning { get; }

        private CommandList _commands;

        private StartGame _firstStartGame = new();

        private Stages _stages;

        public Game()
        {
            _stages = new Stages(0, 10);
            IsRunning = true;
            /**Initalize list of _commands that can be used by the game. To dev: Only ever add or remove _commands in CommandList.*/
            _commands = new CommandList();
            AddRulesForGame();
            GameplayLoop();
        }

        private void AddRulesForGame()
        {
            bool IsDone = false;
            bool IsInt;
            int intCommand = 0;

            while (!IsDone)
            {
                PrepareInfo();

                string command = Console.ReadLine();

                if (command.ToLower() == "continue")
                {
                    SManager.ScreenInfo.ResetInfo();
                    IsDone = true;
                    return;
                }

                if (command.Length == 1) IsInt = int.TryParse(command, out intCommand);
                else IsInt = false;

                if (IsInt && intCommand is <= RulesDictionary.CoreRulesDescriptionsLength and > 0)
                {
                    if (!_commands.Rules.FinalRules.Contains(
                        RulesDictionary.CoreRuleDescriptions[(byte) (intCommand - 1)]))
                    {
                        _commands.Rules.AddRule(RulesDictionary.CoreRuleDescriptions[(byte)(intCommand - 1)]);
                    }
                }
            }
        }

        private void PrepareInfo()
        {
            SManager.ScreenInfo.ResetInfo();
            SManager.ScreenInfo.AddInfo("Welcome to a new Nuzlocke challenge.");
            SManager.ScreenInfo.AddInfo(
                "Choose the rules you want by typing 1-6 and pressing enter. Type \"continue\" when you are done adding rules.");
            SManager.ScreenInfo.AddInfo(" ");
            for (byte i = 0; i < RulesDictionary.CoreRulesDescriptionsLength; i++)
            {
                SManager.ScreenInfo.AddInfo((i + 1).ToString(), RulesDictionary.CoreRuleDescriptions[i]);
            }
            SManager.ScreenInfo.AddInfo(" ");
            SManager.ScreenInfo.AddInfo("These are the rules you have added so far:");
            SManager.ScreenInfo.AddInfo(_commands.Rules.FinalRules);
            SManager.ScreenInfo.PrintInfo();
        }

        private void GameplayLoop()
        {
            SManager.ScreenInfo.AddInfo(StageInfo.Messages[0]);

            while (IsRunning)
            {
                SManager.ScreenInfo.PrintInfo();

                HandleCommand();
            }
        }

        public void HandleCommand()
        {

            string command = Console.ReadLine();

            if (_stages.CurrentStage > 0)
            {
                foreach (Command _command in _commands.Commands)
                {
                    if (_command.CommandName == command.ToLower())
                    {
                        _command.RunCommand();
                    }
                }
            }

            else if (_stages.CurrentStage == 0 && command == "startgame") _firstStartGame.RunCommand();

            else return;
            
        }

        
    }
}
