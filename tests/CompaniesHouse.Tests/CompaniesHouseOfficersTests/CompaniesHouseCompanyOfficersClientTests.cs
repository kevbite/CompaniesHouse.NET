using System;
using System.Net.Http;
using System.Threading.Tasks;
using CompaniesHouse.Tests.ResourceBuilders;
using CompaniesHouse.UriBuilders;
using Moq;
using Shouldly;
using Xunit;
using Officers = CompaniesHouse.Response.Officers.Officers;

namespace CompaniesHouse.Tests.CompaniesHouseOfficersTests
{
    public class CompaniesHouseCompanyOfficersClientTests
    {
        private CompaniesHouseOfficersClient _client;

        private CompaniesHouseClientResponse<Officers> _result;
        private ResourceBuilders.Officers _officers;

        [Fact]
        public async Task GivenACompaniesHouseCompanyProfileClient_WhenGettingACompanyProfile()
        {
            _officers = new OfficersBuilder().Build();
            var resource = new OfficersResourceBuilder(_officers).Create();

            var uri = new Uri("https://wibble.com/search/companies");

            HttpMessageHandler handler = new StubHttpMessageHandler(uri, resource);

            var uriBuilder = new Mock<IOfficersUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(uri);

            _client = new CompaniesHouseOfficersClient(new HttpClient(handler), uriBuilder.Object);

            _result = await _client.GetOfficersAsync("abc", 0, 25);

            EquivalencyAssertionExtensions.ShouldBeEquivalentTo((object)_result.Data, _officers);
        }
    }
}
