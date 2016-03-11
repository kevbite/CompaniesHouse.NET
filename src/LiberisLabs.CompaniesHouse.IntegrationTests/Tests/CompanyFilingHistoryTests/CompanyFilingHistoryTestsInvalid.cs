using NUnit.Framework;

namespace LiberisLabs.CompaniesHouse.IntegrationTests.Tests.CompanyFilingHistoryTests
{
    [TestFixture]
    public class CompanyFilingHistoryTestsInvalid : CompanyFilingHistoryTestBase
    {
        private const string InvalidCompanyNumber = "ABC00000";

        protected override void When()
        {
            WhenRetrievingAnCompanyFilingHistoryForAnInvalidCompany();
        }

        [Test]
        public void ThenTheDataItemsAreNull()
        {
            Assert.That(_result.Data.Items, Is.Null);
        }

        private void WhenRetrievingAnCompanyFilingHistoryForAnInvalidCompany()
        {
            _result = _client.GetCompanyFilingHistoryAsync(InvalidCompanyNumber).Result;
        }
    }
}
