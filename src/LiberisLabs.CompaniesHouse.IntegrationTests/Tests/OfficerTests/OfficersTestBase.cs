using System;
using LiberisLabs.CompaniesHouse.Response.Officers;
using NUnit.Framework;

namespace LiberisLabs.CompaniesHouse.IntegrationTests.Tests.OfficerTests
{
    public abstract class OfficersTestBase
    {
        protected CompaniesHouseClient _client;
        protected CompaniesHouseClientResponse<Officers> _result;

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
