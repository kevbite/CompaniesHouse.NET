using System;
using NUnit.Framework;
using LiberisLabs.CompaniesHouse.Response.CompanyProfile;

namespace LiberisLabs.CompaniesHouse.IntegrationTests.Tests
{
    [TestFixture]
    public abstract class CompanyProfileTestsBase
    {
        protected CompaniesHouseClient _client;
        protected CompaniesHouseClientResponse<CompanyProfile> _result;

        [SetUp]
        public void Setup()
        {
            GivenACompaniesHouseClient();
            When();
        }

        protected abstract void When();

        private void GivenACompaniesHouseClient()
        {
            var apiKey = Environment.GetEnvironmentVariable("CompaniesHouseApiKey");
            var settings = new CompaniesHouseSettings(apiKey);
            _client = new CompaniesHouseClient(settings);
        }
    }
}
