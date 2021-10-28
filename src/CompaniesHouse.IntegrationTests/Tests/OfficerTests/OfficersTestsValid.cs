using System.Threading.Tasks;
using CompaniesHouse.Response.Officers;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.OfficerTests
{
    [TestFixture]
    public class OfficersTestsValid : OfficersTestBase<Officers>
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
            Assert.That(Result.Data.Items, Is.Not.Empty);
        }

        private async Task WhenRetrievingAnCompanyFilingHistoryForAValidCompany()
        {
            Result = await Client.GetOfficersAsync(ValidCompanyNumber)
                .ConfigureAwait(false);
        }
    }
}
