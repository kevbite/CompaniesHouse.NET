using System.Threading.Tasks;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.CompanyFilingHistoryTests
{
    public abstract class CompanyFilingHistoryTestBase : IAsyncLifetime
    {
        protected CompaniesHouseClient _client = null!;

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
            _client = new CompaniesHouseClient(settings);
        }
    }
}