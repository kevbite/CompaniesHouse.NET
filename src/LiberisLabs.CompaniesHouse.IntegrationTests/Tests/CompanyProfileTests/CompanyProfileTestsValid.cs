using NUnit.Framework;

namespace LiberisLabs.CompaniesHouse.IntegrationTests.Tests.CompanyProfileTests
{
    [TestFixture]
    public class CompanyProfileTestsValid : CompanyProfileTestsBase
    {
        // Google UK company number, unlikely to go away soon
        private const string ValidCompanyNumber = "03977902";

        [SetUp]
        protected override void When()
        {
            WhenRetrievingAValidCompanyProfile();
        }

        [Test]
        public void ThenTheProfileIsReturned()
        {
            Assert.That(_result.Data.CompanyName, Is.Not.Empty);
        }

        private void WhenRetrievingAValidCompanyProfile()
        {
            _result = _client.GetCompanyProfileAsync(ValidCompanyNumber).Result;
        }
    }
}
