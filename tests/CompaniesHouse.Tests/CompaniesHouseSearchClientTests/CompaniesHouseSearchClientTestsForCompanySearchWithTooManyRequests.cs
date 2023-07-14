using System;
using System.Net.Http;
using System.Threading.Tasks;
using CompaniesHouse.Request;
using CompaniesHouse.Response.Search.CompanySearch;
using CompaniesHouse.UriBuilders;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace CompaniesHouse.Tests.CompaniesHouseSearchClientTests
{
    [TestFixture]
    public class CompaniesHouseSearchClientTestsForCompanySearchWithTooManyRequests
    {
        private Exception _caughtException;

        [OneTimeSetUp]
        public async Task GivenACompanyHouseSearchCompanyClient_WhenSearchingForACompanyAndApiReturnsTooManyRequests()
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

        [Test]
        public void ThenExceptionIsThrown()
        {
            _caughtException.Should().BeOfType<HttpRequestException>();

            _caughtException.As<HttpRequestException>().Message.Should().StartWith("Response status code does not indicate success: 429");
        }

    }
}