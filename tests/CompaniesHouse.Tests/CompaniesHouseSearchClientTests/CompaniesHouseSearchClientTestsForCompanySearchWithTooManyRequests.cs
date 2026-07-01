using System;
using System.Net.Http;
using System.Threading.Tasks;
using CompaniesHouse.Request;
using CompaniesHouse.Response.Search.CompanySearch;
using CompaniesHouse.UriBuilders;
using Moq;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.CompaniesHouseSearchClientTests
{
    public class CompaniesHouseSearchClientTestsForCompanySearchWithTooManyRequests : IAsyncLifetime
    {
        private CompaniesHouseClientResponse<CompanySearch>? _response;

        public async Task InitializeAsync()
        {
            var uri = new Uri("https://wibble.com/search/companies");

            HttpMessageHandler handler = new TooManyRequestsHttpMessageHandler();

            var client = new CompaniesHouseSearchClient(new HttpClient(handler)
            {
                BaseAddress = new Uri("https://wibble.com/")
            }, new SearchUriBuilderFactory());

            _response = await client.SearchAsync<SearchCompanyRequest, CompanySearch>(new SearchCompanyRequest());
        }

        public Task DisposeAsync() => Task.CompletedTask;

        [Fact]
        public void ThenUnsuccessfulResponseIsReturned()
        {
            _response.ShouldNotBeNull();
            _response.IsSuccess.ShouldBeFalse();
            _response.StatusCode.ShouldBe(429);
            _response.Data.ShouldBeNull();
        }
    }
}