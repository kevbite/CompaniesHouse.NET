using System;
using LiberisLabs.CompaniesHouse.Request;
using NUnit.Framework;

namespace LiberisLabs.CompaniesHouse.IntegrationTests.Tests
{
    [TestFixture]
    public class CompanyProfileTests
    {
        private CompaniesHouseSettings _settings;

        [TestFixtureSetUp]
        public void Setup()
        {
            var apiKey = "QMA5Ll3K0YDHwObXHn6rSFDYAqBanaDU2WLU8Do4";//Environment.GetEnvironmentVariable("CompaniesHouseApiKey");
            _settings = new CompaniesHouseSettings(apiKey);
        }

        [Test]
        public void CheckCompanyProfileIsReturned()
        {
            const string companyNumber = "03977902"; // Google UK company number, unlikely to go away soon
            var client = new CompaniesHouseClient(_settings);

            var result = client.GetCompanyProfileAsync(companyNumber).Result;

            Assert.That(result.Data.CompanyName, Is.Not.Empty);
        }
    }
}
