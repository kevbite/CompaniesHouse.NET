using System;
using System.Net.Http;
using System.Threading.Tasks;
using CompaniesHouse.Response.PersonsWithSignificantControl;
using CompaniesHouse.Tests.ResourceBuilders;
using CompaniesHouse.UriBuilders;
using Moq;
using Shouldly;
using Xunit;
using PersonsWithSignificantControl = CompaniesHouse.Response.PersonsWithSignificantControl.PersonsWithSignificantControl;

namespace CompaniesHouse.Tests.CompaniesHousePersonsWithSignificantControlTests
{
    public class CompaniesHousePersonsWithSignificantControlTests
    {
        private CompaniesHousePersonsWithSignificantControlClient _client = null!;

        private CompaniesHouseResponse<PersonsWithSignificantControl> _result = null!;
        private ResourceBuilders.PersonsWithSignificantControl _personsWithSignificantControl = null!;

        [Fact]
        public async Task GivenACompaniesHouseCompanyProfileClient_WhenGettingPersonsWithSignificantControl()
        {
            _personsWithSignificantControl = new PersonsWithSignificantControlBuilder().Build();
            var resource = new PersonsWithSignificantControlResourceBuilder(_personsWithSignificantControl).Create();

            var uri = new Uri("https://wibble.com/search/companies");

            HttpMessageHandler handler = new StubHttpMessageHandler(uri, resource);

            var uriBuilder = new Mock<IPersonsWithSignificantControlBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(uri);

            _client = new CompaniesHousePersonsWithSignificantControlClient(new HttpClient(handler), uriBuilder.Object);

            _result = await _client.GetPersonsWithSignificantControlAsync("abc", 0, 25);

            EquivalencyAssertionExtensions.ShouldBeEquivalentTo((object)_result.Data, _personsWithSignificantControl);
        }

        [Fact]
        public async Task GivenARealCapturedCorporatePscList_WhenGettingPersonsWithSignificantControl_ThenTotalsAndIdentificationDeserialize()
        {
            const string json = """
                {
                  "items_per_page":10,
                  "items":[
                    {
                      "etag":"d42a48004c06ea9a50976a58f16d2a70ac6ed820",
                      "notified_on":"2016-04-06",
                      "name":"Alphabet, Inc.",
                      "links":{"self":"/company/03977902/persons-with-significant-control/corporate-entity/cdqMtbUIfvMc4RgPpHEhBM8trCs"},
                      "identification":{"legal_form":"Corporate","legal_authority":"Delaware Secretary Of State","country_registered":"Delaware","place_registered":"Delaware","registration_number":"5786925"},
                      "ceased":false,
                      "kind":"corporate-entity-person-with-significant-control",
                      "address":{"address_line_1":"251 Little Falls Drive","country":"United States","locality":"Wilmington","postal_code":"19808","premises":"Corporation Service Company","region":"Delaware"},
                      "natures_of_control":["ownership-of-shares-75-to-100-percent","voting-rights-75-to-100-percent","right-to-appoint-and-remove-directors"]
                    }
                  ],
                  "start_index":0,
                  "total_results":1,
                  "active_count":1,
                  "ceased_count":0,
                  "links":{"self":"/company/03977902/persons-with-significant-control"}
                }
                """;

            var uri = new Uri("https://wibble.com/company/03977902/persons-with-significant-control");
            var handler = new StubHttpMessageHandler(uri, json);
            var uriBuilder = new Mock<IPersonsWithSignificantControlBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(uri);

            var client = new CompaniesHousePersonsWithSignificantControlClient(new HttpClient(handler), uriBuilder.Object);
            var result = await client.GetPersonsWithSignificantControlAsync("03977902", 0, 10);

            result.Data.ShouldNotBeNull();
            result.Data.TotalResults.ShouldBe(1);
            result.Data.Items.ShouldNotBeNull();
            result.Data.Items[0].Kind.ShouldBe(new PersonWithSignificantControlKind("corporate-entity-person-with-significant-control"));
            result.Data.Items[0].Identification?.RegistrationNumber.ShouldBe("5786925");
            (result.Data.Items[0].NaturesOfControl ?? []).ShouldContain(new PersonWithSignificantControlNatureOfControl("right-to-appoint-and-remove-directors"));
        }
    }
}
