using System.Threading.Tasks;
using CompaniesHouse.Response.RegisteredOfficeAddress;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.RegisteredOfficeAddress
{
    public abstract class RegisteredOfficeAddressTestBase : IAsyncLifetime
    {
        protected CompaniesHouseClient Client { get; set; } = null!;
        protected CompaniesHouseClientResponse<OfficeAddress> Result = null!;

        public async Task InitializeAsync()
        {
            GivenACompaniesHouseClient();
            await When();
        }

        public Task DisposeAsync() => Task.CompletedTask;

        protected abstract Task When();

        private void GivenACompaniesHouseClient()
        {
            Client = new CompaniesHouseClient(new CompaniesHouseSettings(CompaniesHouseUris.Default, Keys.ApiKey));
        }
    }
}