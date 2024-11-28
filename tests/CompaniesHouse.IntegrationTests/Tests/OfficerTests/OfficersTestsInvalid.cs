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
        public void ThenTheDataIsFullWithEmptyProperties()
        {
            Assert.That(Result.Data.Items, Is.Empty);
            Assert.That(Result.Data.ActiveCount, Is.EqualTo(0));
            Assert.That(Result.Data.ResignedCount,Is.EqualTo(0));
            Assert.That(Result.Data.StartIndex, Is.EqualTo(0));
            Assert.That(Result.Data.TotalResults, Is.EqualTo(0));;
        }

        private async Task WhenRetrievingAnCompanyFilingHistoryForAnInvalidCompany()
        {
            Result = await Client.GetOfficersAsync(InvalidCompanyNumber).ConfigureAwait(false);
        }
    }
}
