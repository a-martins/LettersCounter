using AutoFixture.Idioms;
using LettersCounter.App;
using LettersCounter.Tests.AutoFixture;
using NSubstitute;
using Xunit;

namespace LettersCounter.Tests
{
    public class OrchestratorTests
    {
        [Theory, AutoNSubstitute]
        public void Sut_ShouldGuardItsClause(GuardClauseAssertion assertion) =>
            assertion.Verify(typeof(Orchestrator).GetConstructors());

        [Theory, AutoNSubstitute]
        public void Sut_DoWork_ShouldCalculateLettersCountCorrectly(
            Orchestrator sut)
        {
            sut.UserInterface.GetValue("Insira o número inicial:").Returns(1);
            sut.UserInterface.GetValue("Insira o número final:").Returns(5);
            sut.NumberConverter.GetWord(1).Returns("um");
            sut.NumberConverter.GetWord(2).Returns("dois");
            sut.NumberConverter.GetWord(3).Returns("tres");
            sut.NumberConverter.GetWord(4).Returns("quatro");
            sut.NumberConverter.GetWord(5).Returns("cinco");

            sut.DoWork();

            sut.ConsoleWrapper.Received().WriteLine($"Total de caracteres: 21");
        }
    }
}