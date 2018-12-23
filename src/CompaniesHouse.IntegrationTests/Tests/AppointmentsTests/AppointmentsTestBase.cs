using System;
using CompaniesHouse.Response.Appointments;
using CompaniesHouse.Response.Officers;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.AppointmentsTests
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

        protected abstract void When();

        private void GivenACompaniesHouseClient()
        {
            var settings = new CompaniesHouseSettings(Keys.ApiKey);
            _client = new CompaniesHouseClient(settings);
        }
    }
}
