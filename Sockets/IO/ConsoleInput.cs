using System;
using UI.Abstractions;

namespace UI.IO
{
    public class ConsoleInput : IInput<string>
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
