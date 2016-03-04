using System;
using LiberisLabs.CompaniesHouse.Response.CompanyFiling;
using NUnit.Framework;

namespace LiberisLabs.CompaniesHouse.IntegrationTests.Tests.CompanyFilingHistoryTests
{
    public abstract class CompanyFilingHistoryTestBase
    {
        protected CompaniesHouseClient _client;
        protected CompaniesHouseClientResponse<CompanyFilingHistory> _result;

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
