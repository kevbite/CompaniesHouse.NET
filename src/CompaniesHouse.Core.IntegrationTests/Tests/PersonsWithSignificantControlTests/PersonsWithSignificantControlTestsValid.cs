using System.Threading.Tasks;
using NUnit.Framework;


namespace CompaniesHouse.Core.IntegrationTests.Tests.PersonsWithSignificantControlTests
{
    [TestFixture]
    public class PersonsWithSignificantControlTestsValid : PersonsWithSignificantControlTestBase
    {
        // Google UK company number, unlikely to go away soon
        private const string ValidCompanyNumber = "03977902";

        [SetUp]
        protected override async Task When()
        {
            await WhenRetrievingAnCompanyPersonsWithSignificantControlForAnValidCompany().ConfigureAwait(false);
        }

        [Test]
        public void ThenTheDataItemsAreNotEmpty()
        {
            Assert.That(_result.Data.Items, Is.Not.Empty);
            Assert.That(_result.Data.Items[0].PersonWithSignificantControlId, Is.Not.Empty);
        }

        private async Task WhenRetrievingAnCompanyPersonsWithSignificantControlForAnValidCompany()
        {
            _result = await _client.GetPersonsWithSignificantControlAsync(ValidCompanyNumber).ConfigureAwait(false);
        }
    }
}
