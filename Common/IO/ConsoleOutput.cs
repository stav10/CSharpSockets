﻿using System;
using Common.Abstractions;

namespace Common.IO
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