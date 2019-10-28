using System.Threading.Tasks;
using CompaniesHouse.Response.DocumentMetadata;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.DocumentMetadataTests
{
    public abstract class DocumentMetadataTestBase
    {
        protected CompaniesHouseClient Client;
        protected CompaniesHouseClientResponse<DocumentMetadata> Result;

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