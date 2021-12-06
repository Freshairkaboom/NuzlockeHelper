using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeHelper
{
    interface ICommand
    {
        string CommandName { get; set; }

        void RunCommand();
    }
}
