using LettersCounter.App.Services.Interfaces;
using LettersCounter.App.Validators.Interfaces;
using LettersCounter.App.Wrappers.Interfaces;
using System;

namespace LettersCounter.App.Services
{
    public class UserInterface : IUserInterface
    {
        public IConsoleWrapper ConsoleWrapper { get; }
        public INumberValidator NumberValidator { get; }

        public UserInterface(IConsoleWrapper consoleWrapper,
            INumberValidator numberValidator)
        {
            ConsoleWrapper = consoleWrapper ?? throw new ArgumentNullException(nameof(consoleWrapper));
            NumberValidator = numberValidator ?? throw new ArgumentNullException(nameof(numberValidator));
        }

        public int GetValue(string message)
        {
            int number;

            ConsoleWrapper.WriteLine(message);
            var inputValue = ConsoleWrapper.ReadLine();
            
            while (!int.TryParse(inputValue, out number) || !NumberValidator.isValid(number))
            {
                ConsoleWrapper.SetForegroundColor(ConsoleColor.Red);
                ConsoleWrapper.WriteLine("Valor inválido!");
                ConsoleWrapper.SetForegroundColor(ConsoleColor.White);
                ConsoleWrapper.WriteLine(message);
                inputValue = ConsoleWrapper.ReadLine();
            }

            return number;
        }
    }
}