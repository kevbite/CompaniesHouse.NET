using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using CompaniesHouse.Request;
using CompaniesHouse.Response.Search.OfficerSearch;
using CompaniesHouse.Tests.ResourceBuilders.OfficerSearchResource;
using CompaniesHouse.UriBuilders;
using Moq;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.CompaniesHouseSearchClientTests
{
    public class CompaniesHouseSearchClientTestsForOfficerSearch : IAsyncLifetime
    {
        private CompaniesHouseSearchClient _client;
        private CompaniesHouseResponse<OfficerSearch> _result;
        private ResourceDetails _resourceDetails;
        
        public async Task InitializeAsync()
        {
            var fixture = new Fixture();
            var items = fixture.Build<Item>()
                .With(x => x.Kind, "searchresults#officer")
                .CreateMany().ToArray();
            _resourceDetails = fixture.Build<ResourceDetails>()
                .With(x => x.Officers, items)
                .Create();
            
            var uri = new Uri("https://wibble.com/search/officers");

            var resource = new OfficerSearchResourceBuilder()
                .CreateResource(_resourceDetails);

            HttpMessageHandler handler = new StubHttpMessageHandler(uri, resource);


            _client = new CompaniesHouseSearchClient(new HttpClient(handler)
            {
                BaseAddress = new Uri("https://wibble.com/")
            }, new SearchUriBuilderFactory());

            _result = await _client.SearchAsync<SearchOfficerRequest, OfficerSearch>(new SearchOfficerRequest());
        }

        public Task DisposeAsync() => Task.CompletedTask;

        [Fact]
        public void ThenResultDataIsCorrect()
        {
            EquivalencyAssertionExtensions.ShouldBeEquivalentTo((object)_result.Data, _resourceDetails, "OfficerId");
        }  
    }
}
