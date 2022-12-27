using System;
using System.Threading.Tasks;
using CompaniesHouse.Response.CompanyProfile;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.CompanyProfileTests
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

        protected abstract Task When();

        private void GivenACompaniesHouseClient()
        {
            var settings = new CompaniesHouseSettings(Keys.ApiKey);
            _client = new CompaniesHouseClient(settings);
        }
    }
}
