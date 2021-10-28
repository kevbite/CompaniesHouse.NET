using System.Threading.Tasks;
using CompaniesHouse.Response.Appointments;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.AppointmentsTests
{
    public abstract class AppointmentsTestBase
    {
        protected CompaniesHouseClient Client;
        protected CompaniesHouseClientResponse<Appointments> Result;

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
