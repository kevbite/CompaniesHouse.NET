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
        private Exception _caughtException;

        public async Task InitializeAsync()
        {
            var uri = new Uri("https://wibble.com/search/companies");

            HttpMessageHandler handler = new TooManyRequestsHttpMessageHandler();

            var client = new CompaniesHouseSearchClient(new HttpClient(handler)
            {
                BaseAddress = new Uri("https://wibble.com/")
            }, new SearchUriBuilderFactory());

            try
            {
                await client.SearchAsync<SearchCompanyRequest, CompanySearch>(new SearchCompanyRequest());
            }
            catch (Exception ex)
            {
                _caughtException = ex;
            }
        }

        public Task DisposeAsync() => Task.CompletedTask;

        [Fact]
        public void ThenExceptionIsThrown()
        {
            var exception = _caughtException.ShouldBeOfType<HttpRequestException>();
            exception.Message.ShouldStartWith("Response status code does not indicate success: 429");
        }

    }
}