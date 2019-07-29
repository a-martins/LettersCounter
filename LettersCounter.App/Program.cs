using LettersCounter.App.Services;
using LettersCounter.App.Services.Interfaces;
using LettersCounter.App.Validators;
using LettersCounter.App.Validators.Interfaces;
using LettersCounter.App.Wrappers;
using LettersCounter.App.Wrappers.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace LettersCounter.App
{
    [ExcludeFromCodeCoverage]
    internal class Program
    {
        private static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddSingleton<INumberConverter, NumberConverter>()
            .AddSingleton<INumberValidator, NumberValidator>()
            .AddSingleton<IConsoleWrapper, ConsoleWrapper>()
            .AddSingleton<IUserInterface, UserInterface>()
            .BuildServiceProvider();

            var orchestrator = new Orchestrator(
                serviceProvider.GetService<INumberConverter>(),
                serviceProvider.GetService<IConsoleWrapper>(),
                serviceProvider.GetService<IUserInterface>());

            orchestrator.DoWork();
        }
    }
}