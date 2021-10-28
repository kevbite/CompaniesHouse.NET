using System.Threading.Tasks;
using CompaniesHouse.Response.Officers;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.OfficerTests
{
    [TestFixture]
    public class OfficersTestsInvalid : OfficersTestBase<Officers>
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
            Assert.That(Result.Data, Is.Null);
        }

        private async Task WhenRetrievingAnCompanyFilingHistoryForAnInvalidCompany()
        {
            Result = await Client.GetOfficersAsync(InvalidCompanyNumber).ConfigureAwait(false);
        }
    }
}
