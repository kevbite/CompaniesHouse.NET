using System.Threading.Tasks;
using CompaniesHouse.Core.Response.PersonsWithSignificantControl;
using NUnit.Framework;

namespace CompaniesHouse.Core.IntegrationTests.Tests.PersonsWithSignificantControlTests
{
    public abstract class PersonsWithSignificantControlTestBase
    {
        protected CompaniesHouseClient _client;
        protected CompaniesHouseClientResponse<PersonsWithSignificantControl> _result;

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
