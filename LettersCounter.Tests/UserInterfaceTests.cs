using AutoFixture.Idioms;
using AutoFixture.Xunit2;
using FluentAssertions;
using LettersCounter.App.Services;
using LettersCounter.Tests.AutoFixture;
using NSubstitute;
using Xunit;

namespace LettersCounter.Tests
{
    public class UserInterfaceTests
    {
        [Theory, AutoNSubstitute]
        public void Sut_ShouldGuardItsClause(GuardClauseAssertion assertion) =>
            assertion.Verify(typeof(UserInterface).GetConstructors());

        [Theory, AutoNSubstitute]
        public void Sut_ShouldReturnAConvertedNumber_When_NumberIsValid(
            UserInterface sut,
            string message)
        {
            sut.ConsoleWrapper.ReadLine().Returns("1");
            sut.NumberValidator.isValid(1).Returns(true);

            var result = sut.GetValue(message);

            result.Should().Be(1);
        }

        [Theory, AutoNSubstitute]
        public void Sut_ShouldNotReturnAConvertedNumber_When_TheFirstInputedNumberIsInValid(
            UserInterface sut,
            string message)
        {
            sut.ConsoleWrapper.ReadLine().Returns("200", "2");
            sut.NumberValidator.isValid(200).Returns(false);
            sut.NumberValidator.isValid(2).Returns(true);

            var result = sut.GetValue(message);

            sut.ConsoleWrapper.Received().WriteLine("Valor inválido!");
        }

        [Theory, AutoNSubstitute]
        public void Sut_ShouldNotReturnAConvertedNumber_When_TheValueInputedIsNotANumber(
            UserInterface sut,
            string message)
        {
            sut.ConsoleWrapper.ReadLine().Returns("J", "2");
            sut.NumberValidator.isValid(2).Returns(true);

            var result = sut.GetValue(message);

            sut.ConsoleWrapper.Received().WriteLine("Valor inválido!");
        }
    }
}