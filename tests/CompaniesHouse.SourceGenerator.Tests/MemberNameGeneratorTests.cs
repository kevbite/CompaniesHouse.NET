using CompaniesHouse.SourceGenerator;
using Shouldly;
using Xunit;

namespace CompaniesHouse.SourceGenerator.Tests
{
    public class MemberNameGeneratorTests
    {
        [Theory]
        [InlineData("active", "Active")]
        [InlineData("voluntary-arrangement", "VoluntaryArrangement")]
        [InlineData("closed-on", "ClosedOn")]
        [InlineData("converted-to-ukeig", "ConvertedToUkeig")]
        [InlineData("accounting-requirements-of-originating-country-do-not-apply", "AccountingRequirementsOfOriginatingCountryDoNotApply")]
        public void ConvertsWireValuesToPascalCase(string wireValue, string expected)
        {
            MemberNameGenerator.ToMemberName(wireValue).ShouldBe(expected);
        }

        [Fact]
        public void MapsEmptyStringToEmptyMemberName()
        {
            MemberNameGenerator.ToMemberName(string.Empty).ShouldBe("Empty");
        }

        [Fact]
        public void PrefixesAnUnderscoreWhenTheResultWouldStartWithADigit()
        {
            MemberNameGenerator.ToMemberName("2024").ShouldBe("_2024");
        }

        [Fact]
        public void CollapsesRunsOfNonAlphanumericCharacters()
        {
            MemberNameGenerator.ToMemberName("foo--bar__baz").ShouldBe("FooBarBaz");
        }
    }
}
