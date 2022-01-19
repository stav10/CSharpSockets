using System;
using UI.Abstractions;

namespace UI.IO
{
    public class ConsoleOutput : IOutput
    {
        public void Print<T>(params T[] values)
        {
            foreach (var value in values)
            {
                Console.WriteLine(value);
            }
        }
    }
}
