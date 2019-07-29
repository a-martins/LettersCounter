using LettersCounter.App.Services.Interfaces;
using LettersCounter.App.Wrappers.Interfaces;
using System;
using System.Linq;

namespace LettersCounter.App
{
    public class Orchestrator
    {
        public INumberConverter NumberConverter { get; }
        public IConsoleWrapper ConsoleWrapper { get; }
        public IUserInterface UserInterface { get; }

        public Orchestrator(INumberConverter numberConverter,
            IConsoleWrapper consoleWrapper,
            IUserInterface userInterface)
        {
            NumberConverter = numberConverter ?? throw new ArgumentNullException(nameof(numberConverter));
            ConsoleWrapper = consoleWrapper ?? throw new ArgumentNullException(nameof(consoleWrapper));
            UserInterface = userInterface ?? throw new ArgumentNullException(nameof(userInterface));
        }

        public void DoWork()
        {
            int initialNumber, finalNumber;
            var totalOfLetters = 0;

            initialNumber = UserInterface.GetValue("Insira o número inicial:");
            finalNumber = UserInterface.GetValue("Insira o número final:");

            var rangeNumbers = Enumerable.Range(initialNumber, finalNumber - initialNumber + 1);

            foreach (var number in rangeNumbers)
            {
                totalOfLetters += NumberConverter.GetWord(number).Length;
            }

            ConsoleWrapper.WriteLine($"Total de caracteres: {totalOfLetters}");
            ConsoleWrapper.ReadLine();
        }
    }
}