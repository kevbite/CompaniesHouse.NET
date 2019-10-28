using System.Threading.Tasks;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.OfficerTests
{
    [TestFixture]
    public class OfficersTestsInvalid : OfficersTestBase
    {
        private const string InvalidCompanyNumber = "ABC00000";

        [SetUp]
        protected override async Task When()
        {
            await WhenRetrievingAnCompanyFilingHistoryForAnInvalidCompany().ConfigureAwait(false);
        }

        [Test]
        public void ThenTheDataItemsAreNull()
        {
            Assert.That(_result.Data, Is.Null);
        }

        private async Task WhenRetrievingAnCompanyFilingHistoryForAnInvalidCompany()
        {
            _result = await _client.GetOfficersAsync(InvalidCompanyNumber).ConfigureAwait(false);
        }
    }
}
