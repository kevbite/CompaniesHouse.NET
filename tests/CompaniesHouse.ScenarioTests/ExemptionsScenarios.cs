using System;
using System.Text.Json;
using CompaniesHouse.Response.Exemptions;
using Shouldly;
using Xunit;

namespace CompaniesHouse.ScenarioTests
{
    public class ExemptionsScenarios
    {
        [Fact]
        public void CompanyExemptions_DeserializesObservedLivePayload()
        {
            var value = JsonSerializer.Deserialize<CompanyExemptions>(ExemptionsJson, CompaniesHouseJsonSerializerOptions.Default);

            value.ShouldNotBeNull();
            value.Kind.ShouldBe("exemptions");
            value.Etag.ShouldBe("95753161ed97c525df753458c24b372ec2909393");
            value.Links.Self.ShouldBe("/company/00445790/exemptions");
            value.Exemptions.PscExemptAsTradingOnUkRegulatedMarket.ShouldNotBeNull();
            value.Exemptions.PscExemptAsTradingOnUkRegulatedMarket.ExemptionType.ShouldBe("psc-exempt-as-trading-on-uk-regulated-market");
            value.Exemptions.PscExemptAsTradingOnUkRegulatedMarket.Items[0].ExemptFrom.ShouldBe(new DateTime(2018, 6, 18));
            value.Exemptions.DisclosureTransparencyRulesChapterFiveApplies.ShouldNotBeNull();
            value.Exemptions.DisclosureTransparencyRulesChapterFiveApplies.Items[0].ExemptTo.ShouldBe(new DateTime(2023, 2, 2));
        }

        private const string ExemptionsJson = """
            {
              "links":{"self":"/company/00445790/exemptions"},
              "kind":"exemptions",
              "etag":"95753161ed97c525df753458c24b372ec2909393",
              "exemptions":{
                "psc_exempt_as_trading_on_uk_regulated_market":{
                  "items":[{"exempt_from":"2018-06-18"}],
                  "exemption_type":"psc-exempt-as-trading-on-uk-regulated-market"
                },
                "disclosure_transparency_rules_chapter_five_applies":{
                  "items":[{"exempt_from":"2017-06-07","exempt_to":"2023-02-02"}],
                  "exemption_type":"disclosure-transparency-rules-chapter-five-applies"
                }
              }
            }
            """;
    }
}
