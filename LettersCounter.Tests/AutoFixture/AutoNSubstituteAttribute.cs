using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;

namespace LettersCounter.Tests.AutoFixture
{
    public class AutoNSubstituteAttribute : AutoDataAttribute
    {
        public AutoNSubstituteAttribute()
            : base(() =>
                 new Fixture()
                     .Customize(new AutoNSubstituteCustomization()))
        {
        }
    }
}