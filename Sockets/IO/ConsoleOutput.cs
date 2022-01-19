using System;
using Common.Abstractions;

namespace UI
{
    public class ConsoleOutput : IOutput<string>
    {
        public void Print(params string[] values)
        {
            throw new NotImplementedException();
        }
    }
}
