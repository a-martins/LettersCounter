using System;

namespace LettersCounter.App.Wrappers.Interfaces
{
    public interface IConsoleWrapper
    {
        void WriteLine(string value);

        string ReadLine();
        void SetForegroundColor(ConsoleColor color);
    }
}