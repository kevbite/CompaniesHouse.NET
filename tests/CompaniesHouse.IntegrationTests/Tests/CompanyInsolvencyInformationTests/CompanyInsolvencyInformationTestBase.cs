using System.Threading.Tasks;
using CompaniesHouse.Response.Insolvency;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.CompanyInsolvencyInformationTests
{
    public abstract class CompanyInsolvencyInformationTestBase : IAsyncLifetime
    {
        protected CompaniesHouseClient Client = null!;
        protected CompaniesHouseResponse<CompanyInsolvencyInformation> Result = null!;

        public async Task InitializeAsync()
        {
            GivenACompaniesHouseClient();
            await When();
        }

        public Task DisposeAsync() => Task.CompletedTask;

        protected abstract Task When();

        private void GivenACompaniesHouseClient()
        {
            Client = new CompaniesHouseClient(new CompaniesHouseSettings(Keys.ApiKey));
        }
    }
}
