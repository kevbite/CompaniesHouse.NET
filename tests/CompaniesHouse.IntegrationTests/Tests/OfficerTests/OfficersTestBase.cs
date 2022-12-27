using System.Threading.Tasks;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.OfficerTests
{
    public abstract class OfficersTestBase<T>
    {
        protected CompaniesHouseClient Client;
        protected CompaniesHouseClientResponse<T> Result;

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
            Client = new CompaniesHouseClient(settings);
        }
    }
}
