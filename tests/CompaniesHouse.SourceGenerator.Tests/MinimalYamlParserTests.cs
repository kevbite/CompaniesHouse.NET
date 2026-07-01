using System.Linq;
using CompaniesHouse.SourceGenerator;
using Shouldly;
using Xunit;

namespace CompaniesHouse.SourceGenerator.Tests
{
    public class MinimalYamlParserTests
    {
        [Fact]
        public void ParsesASingleGroupWithQuotedKeysAndValues()
        {
            const string yaml = """
                company_status:
                    'active' : "Active"
                    'dissolved' : "Dissolved"
                """;

            var groups = MinimalYamlParser.Parse(yaml);

            groups.Count.ShouldBe(1);
            groups[0].Name.ShouldBe("company_status");
            groups[0].Entries.Select(e => (e.Key, e.Value)).ShouldBe(new[]
            {
                ("active", "Active"),
                ("dissolved", "Dissolved"),
            });
        }

        [Fact]
        public void ParsesMultipleGroupsInFirstSeenOrder()
        {
            const string yaml = """
                company_status:
                    'active' : "Active"
                company_type:
                    'ltd' : "Private limited company"
                """;

            var groups = MinimalYamlParser.Parse(yaml);

            groups.Select(g => g.Name).ShouldBe(new[] { "company_status", "company_type" });
            groups[1].Entries.Single().Key.ShouldBe("ltd");
        }

        [Fact]
        public void SkipsBlankLinesCommentsAndDocumentMarkers()
        {
            const string yaml = """
                ---
                # a top level comment
                company_status:
                    # an indented comment
                    'active' : "Active" # trailing comment

                    'dissolved' : "Dissolved"
                """;

            var groups = MinimalYamlParser.Parse(yaml);

            groups.Count.ShouldBe(1);
            groups[0].Entries.Count.ShouldBe(2);
            groups[0].Entries[0].Value.ShouldBe("Active");
        }

        [Fact]
        public void HandlesUnquotedAndEmptyValues()
        {
            const string yaml = """
                company_status_detail:
                    'active' : ""
                    'dissolved': ''
                """;

            var groups = MinimalYamlParser.Parse(yaml);

            groups[0].Entries.Select(e => (e.Key, e.Value)).ShouldBe(new[]
            {
                ("active", ""),
                ("dissolved", ""),
            });
        }

        [Fact]
        public void DoesNotTreatAHashInsideAQuotedValueAsAComment()
        {
            const string yaml = """
                company_type:
                    'ltd' : "Private # limited company"
                """;

            var groups = MinimalYamlParser.Parse(yaml);

            groups[0].Entries[0].Value.ShouldBe("Private # limited company");
        }

        [Fact]
        public void ReturnsNoGroupsForEmptyInput()
        {
            MinimalYamlParser.Parse(string.Empty).ShouldBeEmpty();
        }

        [Fact]
        public void IgnoresIndentedLinesBeforeAnyGroupHeader()
        {
            const string yaml = """
                    'orphan' : "Should be ignored"
                company_status:
                    'active' : "Active"
                """;

            var groups = MinimalYamlParser.Parse(yaml);

            groups.Count.ShouldBe(1);
            groups[0].Entries.Single().Key.ShouldBe("active");
        }
    }
}
