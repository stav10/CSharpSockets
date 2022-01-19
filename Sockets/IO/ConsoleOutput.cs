using System;
using Common.Abstractions;

namespace UI
{
    public class ConsoleStringOutput : IOutput
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
