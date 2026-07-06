using System.Linq;
using CompaniesHouse.SourceGenerator;
using Shouldly;
using Xunit;

namespace CompaniesHouse.SourceGenerator.Tests
{
    public class EnumMapParserTests
    {
        [Fact]
        public void ParsesAWellFormedEntry()
        {
            var entries = EnumMapParser.Parse("company_status|CompaniesHouse.Response|CompanyStatus|true");

            entries.Count.ShouldBe(1);
            entries[0].Group.ShouldBe("company_status");
            entries[0].Namespace.ShouldBe("CompaniesHouse.Response");
            entries[0].TypeName.ShouldBe("CompanyStatus");
            entries[0].IncludeDescriptions.ShouldBeTrue();
        }

        [Fact]
        public void SkipsBlankLinesAndCommentLines()
        {
            const string text = """
                # a comment

                company_status|CompaniesHouse.Response|CompanyStatus|true
                """;

            var entries = EnumMapParser.Parse(text);

            entries.Count.ShouldBe(1);
        }

        [Fact]
        public void SkipsMalformedLinesWithTheWrongNumberOfFields()
        {
            var entries = EnumMapParser.Parse("company_status|CompaniesHouse.Response|CompanyStatus");

            entries.ShouldBeEmpty();
        }

        [Fact]
        public void TreatsAMissingOrUnparsableIncludeDescriptionsFlagAsFalse()
        {
            var entries = EnumMapParser.Parse("company_status|CompaniesHouse.Response|CompanyStatus|notabool");

            entries.Single().IncludeDescriptions.ShouldBeFalse();
        }
    }
}
