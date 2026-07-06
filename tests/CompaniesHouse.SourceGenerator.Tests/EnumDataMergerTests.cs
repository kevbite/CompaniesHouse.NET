using System.Collections.Generic;
using System.Linq;
using CompaniesHouse.SourceGenerator;
using Shouldly;
using Xunit;

namespace CompaniesHouse.SourceGenerator.Tests
{
    public class EnumDataMergerTests
    {
        [Fact]
        public void LaterSourcesOverrideDescriptionsForTheSameWireValue()
        {
            var submodule = MinimalYamlParser.Parse("""
                company_status:
                    'active' : "Active"
                    'closed' : "Closed"
                """);

            var extras = MinimalYamlParser.Parse("""
                company_status:
                    'closed' : "Overridden closed description"
                """);

            var merged = EnumDataMerger.Merge(new[] { submodule, extras });

            merged["company_status"].GetDescription("closed").ShouldBe("Overridden closed description");
            merged["company_status"].GetDescription("active").ShouldBe("Active");
        }

        [Fact]
        public void LaterSourcesAppendNewWireValuesToAnExistingGroup()
        {
            var submodule = MinimalYamlParser.Parse("""
                company_status:
                    'active' : "Active"
                """);

            var extras = MinimalYamlParser.Parse("""
                company_status:
                    'closed-on' : "Closed On"
                """);

            var merged = EnumDataMerger.Merge(new[] { submodule, extras });

            merged["company_status"].WireValues.ShouldBe(new[] { "active", "closed-on" });
        }

        [Fact]
        public void LaterSourcesCanIntroduceABrandNewGroup()
        {
            var submodule = MinimalYamlParser.Parse("""
                company_status:
                    'active' : "Active"
                """);

            var extras = MinimalYamlParser.Parse("""
                library_only_group:
                    'foo' : "Bar"
                """);

            var merged = EnumDataMerger.Merge(new[] { submodule, extras });

            merged.Keys.ShouldBe(new[] { "company_status", "library_only_group" }, ignoreOrder: true);
            merged["library_only_group"].WireValues.Single().ShouldBe("foo");
        }

        [Fact]
        public void PreservesFirstSeenOrderOfWireValues()
        {
            var submodule = MinimalYamlParser.Parse("""
                company_status:
                    'active' : "Active"
                    'dissolved' : "Dissolved"
                    'liquidation' : "Liquidation"
                """);

            var merged = EnumDataMerger.Merge(new[] { submodule });

            merged["company_status"].WireValues.ShouldBe(new[] { "active", "dissolved", "liquidation" });
        }
    }
}
