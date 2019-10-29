using System.Threading.Tasks;
using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.AppointmentsTests
{
    [TestFixture]
    public class AppointmentsTestsValid : AppointmentsTestBase
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
        }

        private async Task WhenRetrievingAnCompanyFilingHistoryForAValidCompany()
        {
            var res = await _client.GetOfficersAsync(ValidCompanyNumber)
                .ConfigureAwait(false);            
            _result = await _client.GetAppointmentsAsync(res.Data.Items[0].OfficerId)
                .ConfigureAwait(false);
        }
    }
}
