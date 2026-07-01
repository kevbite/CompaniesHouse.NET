using System.Threading.Tasks;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.DocumentTests
{
    public abstract class DocumentTestBase<T> : IAsyncLifetime
    {
        protected CompaniesHouseDocumentClient Client = null!;
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
            Client = new CompaniesHouseDocumentClient(new CompaniesHouseSettings(CompaniesHouseUris.DocumentApi, Keys.ApiKey));
        }
    }
}