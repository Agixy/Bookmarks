using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTools.Menu
{
    public class GeneralOption : IMenuOption
    {
        private Action _execute;
        public string Description { get; }
        

        public GeneralOption(string description, Action execute)
        {
            Description = description;
            _execute = execute;
        }

        public void Execute()
        {
            _execute();
        }
    }
}
