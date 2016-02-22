using System;
using LiberisLabs.CompaniesHouse.Response.CompanyProfile;
using NUnit.Framework;

namespace LiberisLabs.CompaniesHouse.IntegrationTests.Tests.CompanyProfileTests
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
