using System;
using Common.Abstractions;

namespace UI
{
    public class ConsoleInput : IInput<string>
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
