using System;
using System.Net.Http;
using FluentAssertions;
using LiberisLabs.CompaniesHouse.Tests.ResourceBuilders;
using LiberisLabs.CompaniesHouse.UriBuilders;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using CompanyProfile = LiberisLabs.CompaniesHouse.Response.CompanyProfile.CompanyProfile;

namespace LiberisLabs.CompaniesHouse.Tests
{
    [TestFixture]
    public class CompaniesHouseCompanyProfileClientTests
    {
        private CompaniesHouseCompanyProfileClient _client;

        private CompaniesHouseClientResponse<CompanyProfile> _result;
        private ResourceBuilders.CompanyProfile _companyProfile;


        [TestFixtureSetUp]
        public void GivenACompaniesHouseCompanyProfileClient_WhenGettingACompanyProfile()
        {
            var fixture = new Fixture();

            var uri = new Uri("https://wibble.com/search/companies");

            _companyProfile = fixture.Build<ResourceBuilders.CompanyProfile>().Create();
            var resource = new CompanyProfileResourceBuilder(_companyProfile)
                .Create();

            HttpMessageHandler handler = new StubHttpMessageHandler(uri, resource);
            var httpClientFactory = new Mock<IHttpClientFactory>();
            httpClientFactory.Setup(x => x.CreateHttpClient())
                .Returns(new HttpClient(handler));

            var uriBuilder = new Mock<ICompanyProfileUriBuilder>();
            uriBuilder.Setup(x => x.Build(It.IsAny<string>()))
                .Returns(uri);

            _client = new CompaniesHouseCompanyProfileClient(httpClientFactory.Object, uriBuilder.Object);

            _result = _client.GetCompanyProfileAsync("abc").Result;
        }

        [Test]
        public void ThenTheRootIsCorrect()
        {
            _result.ShouldBeEquivalentTo(_companyProfile);
        }
    }
}
