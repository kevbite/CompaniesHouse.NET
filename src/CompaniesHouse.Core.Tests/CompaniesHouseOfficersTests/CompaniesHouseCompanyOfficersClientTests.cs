using System;
using System.Net.Http;
using CompaniesHouse.Core.Tests.ResourceBuilders;
using CompaniesHouse.Core.UriBuilders;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Officers = CompaniesHouse.Response.Officers.Officers;

namespace CompaniesHouse.Core.Tests.CompaniesHouseOfficersTests
{
    [TestFixture]
    public class CompaniesHouseCompanyOfficersClientTests
    {
        private CompaniesHouseOfficersClient _client;

        private CompaniesHouseClientResponse<Officers> _result;
        private ResourceBuilders.Officers _officers;

        [Test]
        public void GivenACompaniesHouseCompanyProfileClient_WhenGettingACompanyProfile()
        {
            _officers = new OfficersBuilder().Build();
            var resource = new OfficersResourceBuilder(_officers).Create();

            var uri = new Uri("https://wibble.com/search/companies");

            HttpMessageHandler handler = new StubHttpMessageHandler(uri, resource);

            var uriBuilder = new Mock<IOfficersUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(uri);

            _client = new CompaniesHouseOfficersClient(new HttpClient(handler), uriBuilder.Object);

            _result = _client.GetOfficersAsync("abc", 0, 25).Result;

            _result.Data.ShouldBeEquivalentTo(_officers);
        }
    }
}
