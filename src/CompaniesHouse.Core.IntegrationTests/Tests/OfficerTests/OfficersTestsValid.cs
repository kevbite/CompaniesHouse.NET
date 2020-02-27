using System.Threading.Tasks;
using NUnit.Framework;

namespace CompaniesHouse.Core.IntegrationTests.Tests.OfficerTests
{
    [TestFixture]
    public class OfficersTestsValid : OfficersTestBase
    {
        // Google UK company number, unlikely to go away soon
        private const string ValidCompanyNumber = "03977902";

        [SetUp]
        protected override async Task When()
        {
            await WhenRetrievingAnCompanyFilingHistoryForAValidCompany()
                .ConfigureAwait(false);
        }

        [Test]
        public void ThenTheDataItemsAreNotEmpty()
        {
            Assert.That(_result.Data.Items, Is.Not.Empty);
            Assert.That(_result.Data.Items[0].OfficerId, Is.Not.Empty);
        }

        private async Task WhenRetrievingAnCompanyFilingHistoryForAValidCompany()
        {
            _result = await _client.GetOfficersAsync(ValidCompanyNumber)
                .ConfigureAwait(false);
        }
    }
}
