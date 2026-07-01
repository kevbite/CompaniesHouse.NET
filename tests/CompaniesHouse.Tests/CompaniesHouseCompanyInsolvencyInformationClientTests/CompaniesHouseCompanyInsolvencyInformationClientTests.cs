using System;
using System.Net.Http;
using System.Threading.Tasks;
using CompaniesHouse.Response.Insolvency;
using CompaniesHouse.UriBuilders;
using Moq;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.CompaniesHouseCompanyInsolvencyInformationClientTests
{
    public class CompaniesHouseCompanyInsolvencyInformationClientTests
    {
        [Fact]
        public async Task GivenARealCapturedInsolvencyPayload_WhenGettingCompanyInsolvencyInformation_ThenStatusesAndCaseTypesDeserialize()
        {
            const string json = """
                {
                  "cases":[
                    {
                      "type":"in-administration",
                      "dates":[
                        {"type":"administration-started-on","date":"2012-01-30"},
                        {"type":"administration-ended-on","date":"2013-01-22"}
                      ],
                      "practitioners":[
                        {"name":"Ian Christopher Schofield","address":{"address_line_1":"Pkf (Uk) Llp","address_line_2":"Pannell House","locality":"6 Queen Street","region":"Leeds","postal_code":"LS1 2TW"},"role":"practitioner"},
                        {"name":"Charles William Anthony Escott","address":{"address_line_1":"Pannell House 6 Queen Street","locality":"Leeds","region":"West Yorkshire","postal_code":"LS1 2TW"},"ceased_to_act_on":"2012-06-01","role":"practitioner"}
                      ],
                      "number":"1"
                    }
                  ],
                  "status":["in-administration","administrative-receiver"]
                }
                """;

            var uri = new Uri("https://wibble.com/company/08749409/insolvency");
            HttpMessageHandler handler = new StubHttpMessageHandler(uri, json);
            var uriBuilder = new Mock<ICompanyInsolvencyInformationUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>())).Returns(uri);

            var client = new CompaniesHouseCompanyInsolvencyInformationClient(new HttpClient(handler), uriBuilder.Object);
            var result = await client.GetCompanyInsolvencyInformationAsync("08749409");

            result.Data.ShouldNotBeNull();
            result.Data.Status.ShouldBe([new InsolvencyStatus("in-administration"), new InsolvencyStatus("administrative-receiver")]);
            result.Data.Cases.ShouldNotBeNull();
            result.Data.Cases[0].Type.ShouldBe(InsolvencyCaseType.InAdministration);
            result.Data.Cases[0].Dates.ShouldContain(x => x.Type == new CaseDateType("administration-started-on"));
            result.Data.Cases[0].Practitioners.ShouldContain(x => x.Name == "Charles William Anthony Escott" && x.CeasedToActOn == new DateTime(2012, 06, 01));
        }
    }
}
