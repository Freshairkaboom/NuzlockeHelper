using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeHelper
{
    public class CommandList
    {
        public readonly List<Command> Commands = new();

        public readonly StartGame StartGame = new();
        public readonly NextStage NextStage = new();
        public readonly PreviousStage PreviousStage = new();
        public readonly CloseRoute CloseRoute = new();
        public readonly Rules Rules = new();

        public CommandList()
        {
            Commands.Add(StartGame);
            Commands.Add(NextStage);
            Commands.Add(PreviousStage);
            Commands.Add(CloseRoute);
            Commands.Add(Rules);
        }
    }
}
