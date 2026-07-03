using System;
using System.Net.Http;
using System.Threading.Tasks;
using CompaniesHouse.Response;
using CompaniesHouse.Response.UkEstablishments;
using CompaniesHouse.UriBuilders;
using Moq;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.CompaniesHouseUkEstablishmentsClientTests
{
    public class CompaniesHouseUkEstablishmentsClientTests
    {
        [Fact]
        public async Task GivenCapturedUkEstablishmentsPayload_WhenGettingUkEstablishments_ThenObservedFieldsDeserialize()
        {
            var uri = new Uri("https://wibble.com/company/FC040879/uk-establishments");
            HttpMessageHandler handler = new StubHttpMessageHandler(uri, UkEstablishmentsJson);
            var uriBuilder = new Mock<ICompanyUkEstablishmentsUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>())).Returns(uri);

            var client = new CompaniesHouseUkEstablishmentsClient(new HttpClient(handler), uriBuilder.Object);
            var result = await client.GetCompanyUkEstablishmentsAsync("FC040879");

            result.Data.ShouldNotBeNull();
            result.Data.Kind.ShouldBe("related-companies");
            result.Data.Links.Self.ShouldBe("/company/FC040879");
            result.Data.Items.Length.ShouldBe(1);
            result.Data.Items[0].CompanyNumber.ShouldBe("BR025996");
            result.Data.Items[0].CompanyStatus.ShouldBe(new CompanyStatus("open"));
            result.Data.Items[0].Links.Company.ShouldBe("/company/BR025996");
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
