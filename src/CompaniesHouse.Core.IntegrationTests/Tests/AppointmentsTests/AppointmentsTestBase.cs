using System;
using System.Threading.Tasks;
using CompaniesHouse.Core.Response.Appointments;
using CompaniesHouse.Core.Response.Officers;
using NUnit.Framework;

namespace CompaniesHouse.Core.IntegrationTests.Tests.AppointmentsTests
{
    public abstract class AppointmentsTestBase
    {
        protected CompaniesHouseClient _client;
        protected CompaniesHouseClientResponse<Appointments> _result;

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
