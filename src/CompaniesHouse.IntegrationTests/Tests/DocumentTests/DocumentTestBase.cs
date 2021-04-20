using System.Threading.Tasks;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.DocumentTests
{
    public abstract class DocumentTestBase<T>
    {
        protected CompaniesHouseDocumentClient Client;
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
            Client = new CompaniesHouseDocumentClient(new CompaniesHouseSettings(CompaniesHouseUris.DocumentApi, Keys.ApiKey));
        }
    }
}