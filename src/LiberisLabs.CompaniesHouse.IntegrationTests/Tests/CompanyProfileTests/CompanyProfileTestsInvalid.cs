using NUnit.Framework;

namespace LiberisLabs.CompaniesHouse.IntegrationTests.Tests
{
    [TestFixture]
    public class CompanyProfileTestsInvalid : CompanyProfileTestsBase
    {
        private const string invalidCompanyNumber = "ABC00000";

        [SetUp]
        protected override void When()
        {
            WhenRetrievingAnInvalidCompanyProfile();
        }

        [Test]
        public void ThenTheProfileIsNotReturned()
        {
            Assert.That(_result.Data, Is.Null);
        }

        private void WhenRetrievingAnInvalidCompanyProfile()
        {
            _result = _client.GetCompanyProfileAsync(invalidCompanyNumber).Result;
        }
    }
}
