using NUnit.Framework;

namespace LiberisLabs.CompaniesHouse.IntegrationTests.Tests.OfficerTests
{
    [TestFixture]
    public class OfficersTestsValid : OfficersTestBase
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
            _result = _client.GetOfficersAsync(ValidCompanyNumber).Result;
        }
    }
}
