using System.Threading.Tasks;
using CompaniesHouse.Response.Appointments;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.AppointmentsTests
{
    public abstract class AppointmentsTestBase : IAsyncLifetime
    {
        protected CompaniesHouseClient Client = null!;
        protected CompaniesHouseClientResponse<Appointments> Result = null!;

        public async Task InitializeAsync()
        {
            GivenACompaniesHouseClient();
            await When();
        }

        public Task DisposeAsync() => Task.CompletedTask;

        protected abstract Task When();

        private void GivenACompaniesHouseClient()
        {
            var settings = new CompaniesHouseSettings(Keys.ApiKey);
            Client = new CompaniesHouseClient(settings);
        }
    }
}