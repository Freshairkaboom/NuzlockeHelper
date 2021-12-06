using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeHelper
{
    /*Superclass of every command: Constructs the name of each command used by HandleCommand function,
     * and declares a virtual method called RunCommand for the commands to override.
     */
    public class Command : ICommand
    {
        public string CommandName { get; set; }

        public Command(string commandName)
        {
            CommandName = commandName;
        }

        public virtual void RunCommand() { }
    }
}
