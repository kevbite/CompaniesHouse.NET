using System.Threading.Tasks;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.OfficerTests
{
    public abstract class OfficersTestBase<T> : IAsyncLifetime
    {
        protected CompaniesHouseClient Client = null!;
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
            var settings = new CompaniesHouseSettings(Keys.ApiKey);
            Client = new CompaniesHouseClient(settings);
        }
    }
}