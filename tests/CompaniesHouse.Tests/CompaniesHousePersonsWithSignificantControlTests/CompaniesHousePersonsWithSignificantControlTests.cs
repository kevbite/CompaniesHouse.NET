using System;
using System.Net.Http;
using System.Threading.Tasks;
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
        private CompaniesHousePersonsWithSignificantControlClient _client;

        private CompaniesHouseClientResponse<PersonsWithSignificantControl> _result;
        private ResourceBuilders.PersonsWithSignificantControl _personsWithSignificantControl;

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
    }
}
