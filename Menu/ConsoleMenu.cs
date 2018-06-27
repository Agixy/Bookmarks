using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace ConsoleTools.Menu
{
    public class ConsoleMenu
    {
        private readonly IMenuOption[] _options;

        public ConsoleMenu(IMenuOption[] options)
        {
            _options = options.ToArray();
        }

        public void Show()
        {
            WriteLine("Choose option");
            int i = 1;
            foreach (var option in _options)
            {
                WriteLine($"{i++} {option.Description}");
            }

            uint choice;
            while (!uint.TryParse(ReadLine(), out choice)
                || choice == 0 || choice > _options.Length)
            {
                WriteLine("Not valid option");
            }
            _options[choice - 1].Execute();
        }
    }
}
