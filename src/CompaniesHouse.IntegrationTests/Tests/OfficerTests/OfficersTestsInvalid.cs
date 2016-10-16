using NUnit.Framework;

namespace CompaniesHouse.IntegrationTests.Tests.OfficerTests
{
    [TestFixture]
    public class OfficersTestsInvalid : OfficersTestBase
    {
        private const string InvalidCompanyNumber = "ABC00000";

        [SetUp]
        protected override void When()
        {
            WhenRetrievingAnCompanyFilingHistoryForAnInvalidCompany();
        }

        [Test]
        public void ThenTheDataItemsAreNull()
        {
            Assert.That(_result.Data, Is.Null);
        }

        private void WhenRetrievingAnCompanyFilingHistoryForAnInvalidCompany()
        {
            _result = _client.GetOfficersAsync(InvalidCompanyNumber).Result;
        }
    }
}
