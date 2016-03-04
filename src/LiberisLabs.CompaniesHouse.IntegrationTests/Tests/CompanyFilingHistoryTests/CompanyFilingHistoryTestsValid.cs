using NUnit.Framework;

namespace LiberisLabs.CompaniesHouse.IntegrationTests.Tests.CompanyFilingHistoryTests
{
    [TestFixture]
    public class CompanyFilingHistoryTestsValid : CompanyFilingHistoryTestBase
    {
        // Google UK company number, unlikely to go away soon
        private const string ValidCompanyNumber = "03977902";

        [SetUp]
        protected override void When()
        {
            WhenRetrievingAnInvalidCompanyProfile();
        }

        [Test]
        public void ThenTheProfileIsNotReturned()
        {
            Assert.That(_result.Data.Items, Is.Not.Empty);
        }

        private void WhenRetrievingAnInvalidCompanyProfile()
        {
            _result = _client.GetCompanyFilingHistoryAsync(ValidCompanyNumber).Result;
        }
    }
}
