using System.Text.Json;
using CompaniesHouse.Response;
using CompaniesHouse.Response.UkEstablishments;
using Shouldly;
using Xunit;

namespace CompaniesHouse.ScenarioTests
{
    public class UkEstablishmentsScenarios
    {
        [Fact]
        public void CompanyUkEstablishments_DeserializesObservedLivePayload()
        {
            var value = JsonSerializer.Deserialize<CompanyUkEstablishments>(UkEstablishmentsJson, CompaniesHouseJsonSerializerOptions.Default);

            value.ShouldNotBeNull();
            value.Kind.ShouldBe("related-companies");
            value.Etag.ShouldBe("7d23ba7a5bc001b8bbe553b879ed445c342a9353");
            value.Links.Self.ShouldBe("/company/FC040879");
            value.Items.Length.ShouldBe(1);
            value.Items[0].CompanyName.ShouldBe("ABSA UK PERMANENT ESTABLISHMENT");
            value.Items[0].CompanyStatus.ShouldBe(new CompanyStatus("open"));
            value.Items[0].Links.Company.ShouldBe("/company/BR025996");
        }

        private const string UkEstablishmentsJson = """
            {
              "etag":"7d23ba7a5bc001b8bbe553b879ed445c342a9353",
              "kind":"related-companies",
              "links":{"self":"/company/FC040879"},
              "items":[
                {
                  "company_name":"ABSA UK PERMANENT ESTABLISHMENT",
                  "company_number":"BR025996",
                  "company_status":"open",
                  "locality":"London",
                  "links":{"company":"/company/BR025996"}
                }
              ]
            }
            """;
    }
}
