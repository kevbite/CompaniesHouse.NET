using System;
using NUnit.Framework;
using LiberisLabs.CompaniesHouse.Response.CompanyProfile;

namespace LiberisLabs.CompaniesHouse.IntegrationTests.Tests
{
    [TestFixture]
    public class CompanyProfileTests
    {
        // Google UK company number, unlikely to go away soon
        private const string companyNumber = "03977902";

        private CompaniesHouseClient _client;
        private CompaniesHouseClientResponse<CompanyProfile> _result;

        [TestFixtureSetUp]
        public void GivenACompaniesHouseClient()
        {
            var apiKey = Environment.GetEnvironmentVariable("CompaniesHouseApiKey");

            var settings = new CompaniesHouseSettings(apiKey);

            _client = new CompaniesHouseClient(settings);
        }

        [SetUp]
        public void WhenRetrievingACompanyProfile()
        {
            _result = _client.GetCompanyProfileAsync(companyNumber).Result;
        }

        [Test]
        public void ThenTheProfileIsReturned()
        {
            Assert.That(_result.Data.CompanyName, Is.Not.Empty);
        }
    }
}
