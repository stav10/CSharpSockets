using System;
using Common.Abstractions;

namespace UI
{
    public class ConsoleOutput : IOutput<string>
    {
        public void Print(params string[] values)
        {
            foreach (var value in values)
            {
                Console.WriteLine(value);
            }
        }
    }
}
