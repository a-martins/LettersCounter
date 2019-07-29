using LettersCounter.App.Wrappers.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;

namespace LettersCounter.App.Wrappers
{
    [ExcludeFromCodeCoverage]
    public class ConsoleWrapper : IConsoleWrapper
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void SetForegroundColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }


    }
}