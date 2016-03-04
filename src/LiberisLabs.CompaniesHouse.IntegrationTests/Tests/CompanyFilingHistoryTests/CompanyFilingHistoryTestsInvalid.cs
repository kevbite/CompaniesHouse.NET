using NUnit.Framework;

namespace LiberisLabs.CompaniesHouse.IntegrationTests.Tests.CompanyFilingHistoryTests
{
    [TestFixture]
    public class CompanyFilingHistoryTestsInvalid : CompanyFilingHistoryTestBase
    {
        private const string InvalidCompanyNumber = "ABC00000";

        [SetUp]
        protected override void When()
        {
            WhenRetrievingAnInvalidCompanyProfile();
        }

        [Test]
        public void ThenTheProfileIsNotReturned()
        {
            Assert.That(_result.Data.Items, Is.Null);
        }

        private void WhenRetrievingAnInvalidCompanyProfile()
        {
            _result = _client.GetCompanyFilingHistoryAsync(InvalidCompanyNumber).Result;
        }
    }
}
