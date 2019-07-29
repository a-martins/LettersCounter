using AutoFixture.Xunit2;
using Xunit;

namespace LettersCounter.Tests.AutoFixture
{
    public class AutoInlineDataAttribrute : CompositeDataAttribute
    {
        public AutoInlineDataAttribrute(params object[] values)
            : base(new InlineDataAttribute(values), new AutoDataAttribute())
        {
        }
    }
}