using System.Threading.Tasks;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.ChargesTests
{
    public abstract class ChargesTestBase<T> : IAsyncLifetime
    {
        protected CompaniesHouseClient Client { get; set; } = null!;
        protected CompaniesHouseClientResponse<T> Result = null!;

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