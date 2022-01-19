using System;
using Common.Abstractions;

namespace Common.IO
{
    public class ConsoleInput : IInput<string>
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
