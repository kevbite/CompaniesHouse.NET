using System.Threading.Tasks;
using NUnit.Framework;

namespace CompaniesHouse.Core.IntegrationTests.Tests.DocumentTests
{
    public abstract class DocumentTestBase<T>
    {
        protected CompaniesHouseClient Client;
        protected CompaniesHouseClientResponse<T> Result;

        [SetUp]
        public async Task Setup()
        {
            GivenACompaniesHouseClient();
            await When().ConfigureAwait(false);
        }

        protected abstract Task When();

        private void GivenACompaniesHouseClient()
        {
            Client = new CompaniesHouseClient(new CompaniesHouseSettings(CompaniesHouseUris.DocumentApi, Keys.ApiKey));
        }
    }
}