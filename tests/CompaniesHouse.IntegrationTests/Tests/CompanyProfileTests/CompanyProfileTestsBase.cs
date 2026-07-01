using System.Threading.Tasks;
using CompaniesHouse.Response.CompanyProfile;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.CompanyProfileTests
{
    public abstract class CompanyProfileTestsBase : IAsyncLifetime
    {
        protected CompaniesHouseClient _client = null!;
        protected CompaniesHouseClientResponse<CompanyProfile> _result = null!;

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