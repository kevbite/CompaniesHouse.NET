using System;
using System.Net.Http;
using System.Threading.Tasks;
using CompaniesHouse.Response.Exemptions;
using CompaniesHouse.UriBuilders;
using Moq;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.CompaniesHouseExemptionsClientTests
{
    public class CompaniesHouseExemptionsClientTests
    {
        [Fact]
        public async Task GivenCapturedExemptionsPayload_WhenGettingExemptions_ThenObservedFieldsDeserialize()
        {
            var uri = new Uri("https://wibble.com/company/00445790/exemptions");
            HttpMessageHandler handler = new StubHttpMessageHandler(uri, ExemptionsJson);
            var uriBuilder = new Mock<ICompanyExemptionsUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>())).Returns(uri);

            var client = new CompaniesHouseExemptionsClient(new HttpClient(handler), uriBuilder.Object);
            var result = await client.GetCompanyExemptionsAsync("00445790");

            result.Data.ShouldNotBeNull();
            result.Data.Kind.ShouldBe("exemptions");
            result.Data.Links.Self.ShouldBe("/company/00445790/exemptions");
            result.Data.Exemptions.PscExemptAsTradingOnUkRegulatedMarket.ShouldNotBeNull();
            result.Data.Exemptions.PscExemptAsTradingOnUkRegulatedMarket.ExemptionType.ShouldBe("psc-exempt-as-trading-on-uk-regulated-market");
            result.Data.Exemptions.PscExemptAsTradingOnUkRegulatedMarket.Items[0].ExemptFrom.ShouldBe(new DateTime(2018, 6, 18));
            result.Data.Exemptions.DisclosureTransparencyRulesChapterFiveApplies.ShouldNotBeNull();
            result.Data.Exemptions.DisclosureTransparencyRulesChapterFiveApplies.Items[0].ExemptTo.ShouldBe(new DateTime(2023, 2, 2));
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
