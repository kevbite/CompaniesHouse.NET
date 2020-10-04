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

            var uriBuilder = new Mock<ISearchUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<SearchRequest>()))
                .Returns(uri);

            var uriBuilderFactory = new Mock<ISearchUriBuilderFactory>();
            uriBuilderFactory.Setup(x => x.Create<CompanySearch>())
                .Returns(uriBuilder.Object);

            var client = new CompaniesHouseSearchClient(new HttpClient(handler), uriBuilderFactory.Object);

            try
            {
                await client.SearchAsync<CompanySearch>(new SearchRequest());
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