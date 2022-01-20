using Common.Abstractions;
using System;

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
