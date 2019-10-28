using CompaniesHouse.Response.DocumentMetadata;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.DocumentMetadataTests
{
    public abstract class DocumentMetadataTestBase
    {
        protected CompaniesHouseClient Client;
        protected CompaniesHouseClientResponse<DocumentMetadata> Result;

        [SetUp]
        public void Setup()
        {
            GivenACompaniesHouseClient();
            When();
        }

        protected abstract void When();

        private void GivenACompaniesHouseClient()
        {
            Client = new CompaniesHouseClient(new CompaniesHouseSettings(CompaniesHouseUris.DocumentApi, Keys.ApiKey));
        }
    }
}