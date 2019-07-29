using AutoFixture.Xunit2;
using FluentAssertions;
using LettersCounter.App.Validators;
using LettersCounter.Tests.AutoFixture;
using Xunit;

namespace LettersCounter.Tests
{
    public class NumberValidatorTests
    {
        [Theory, AutoData]
        public void Sut_IsValid_WhenReceiveAMinusZeroNumber_ShouldReturnFalse(
            NumberValidator sut)
        {
            var result = sut.isValid(-1);
            result.Should().BeFalse();
        }

        [Theory, AutoData]
        public void Sut_IsValid_WhenReceiveANumberGreaterThan100_ShouldReturnFalse(
            NumberValidator sut)
        {
            var result = sut.isValid(101);
            result.Should().BeFalse();
        }

        [Theory]
        [AutoInlineDataAttribrute(0)]
        [AutoInlineDataAttribrute(50)]
        [AutoInlineDataAttribrute(100)]
        public void Sut_IsValid_WhenReceiveANumberBetween0And100_ShouldReturnTrue(
            int number, NumberValidator sut)
        {
            var result = sut.isValid(number);
            result.Should().BeTrue();
        }
    }
}