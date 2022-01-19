using System;
using Common.Abstractions;

namespace UI
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
