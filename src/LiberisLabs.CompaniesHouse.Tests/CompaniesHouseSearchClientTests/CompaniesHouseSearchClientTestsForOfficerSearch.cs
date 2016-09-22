using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using LiberisLabs.CompaniesHouse.Request;
using LiberisLabs.CompaniesHouse.Response.OfficerSearch;
using LiberisLabs.CompaniesHouse.Tests.ResourceBuilders.OfficerSearchResource;
using LiberisLabs.CompaniesHouse.UriBuilders;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace LiberisLabs.CompaniesHouse.Tests.CompaniesHouseSearchClientTests
{
    [TestFixture]
    public class CompaniesHouseSearchClientTestsForOfficerSearch
    {
        private CompaniesHouseSearchClient _client;
        private CompaniesHouseClientResponse<OfficerSearch> _result;
        private ResourceDetails _resourceDetails;
        
        [OneTimeSetUp]
        public async Task GivenACompanyHouseSearchClient_WhenSearchingForAOfficer()
        {
            var fixture = new Fixture();
            _resourceDetails = fixture.Create<ResourceDetails>();
            
            var uri = new Uri("https://wibble.com/search/companies");

            var resource = new OfficerSearchResourceBuilder()
                .CreateResource(_resourceDetails);

            HttpMessageHandler handler = new StubHttpMessageHandler(uri, resource);
            var httpClientFactory = new Mock<IHttpClientFactory>();
            httpClientFactory.Setup(x => x.CreateHttpClient())
                .Returns(new HttpClient(handler));

            var uriBuilder = new Mock<ISearchUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<SearchRequest>()))
                .Returns(uri);

            var uriBuilderFactory = new Mock<ISearchUriBuilderFactory>();
            uriBuilderFactory.Setup(x => x.Create<OfficerSearch>())
                .Returns(uriBuilder.Object);

            _client = new CompaniesHouseSearchClient(httpClientFactory.Object, uriBuilderFactory.Object);

            _result = await _client.SearchAsync<OfficerSearch>(new SearchRequest());
        }

        [Test]
        public void ThenResultDataIsCorrect()
        {
            _result.Data.ShouldBeEquivalentTo(_resourceDetails);
        }  
    }
}
