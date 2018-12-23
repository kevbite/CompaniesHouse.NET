using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.AppointmentsTests
{
    [TestFixture]
    public class AppointmentsTestsValid : AppointmentsTestBase
    {
        // Google UK company number, unlikely to go away soon
        private const string ValidCompanyNumber = "03977902";

        [SetUp]
        protected override void When()
        {
            WhenRetrievingAnCompanyFilingHistoryForAValidCompany();
        }

        [Test]
        public void ThenTheDataItemsAreNotEmpty()
        {
            Assert.That(_result.Data.Items, Is.Not.Empty);
        }

        private void WhenRetrievingAnCompanyFilingHistoryForAValidCompany()
        {
            var res = _client.GetOfficersAsync(ValidCompanyNumber).Result;            
            _result = _client.GetAppointmentsAsync(res.Data.Items[0].OfficerId).Result;
        }
    }
}
