using FluentAssertions;
using LettersCounter.App.Services;
using LettersCounter.Tests.AutoFixture;
using Xunit;

namespace LettersCounter.Tests
{
    public class NumberConverterTests
    {
        [Theory]
        [AutoInlineDataAttribrute(1, "um")]
        [AutoInlineDataAttribrute(10, "dez")]
        [AutoInlineDataAttribrute(11, "onze")]
        [AutoInlineDataAttribrute(13, "treze")]
        [AutoInlineDataAttribrute(19, "dezenove")]
        [AutoInlineDataAttribrute(30, "trinta")]
        [AutoInlineDataAttribrute(51, "cinquenta e um")]
        [AutoInlineDataAttribrute(100, "cem")]
        public void Sut_GetWord_ShouldReturnTheCorrectWord_WhenReceiveANumber_Between0And100(
            int number, string word, NumberConverter sut)
        {
            var result = sut.GetWord(number);
            result.Should().Be(word);
        }
    }
}