using System;
using Common.Abstractions;

namespace Common.IO
{
    public class ConsoleInput : IInput
    {
        public string ReadString()
        {
            return Console.ReadLine();
        }
        public bool TryRead<T>(IConvertor<string, T> convertor, out T value)
        {
            var input = Console.ReadLine();
            return convertor.TryConvert(input, out value);
        }
    }
}
