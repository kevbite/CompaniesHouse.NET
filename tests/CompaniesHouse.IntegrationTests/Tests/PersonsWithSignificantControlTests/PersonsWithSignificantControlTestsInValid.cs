using System.Threading.Tasks;
using NUnit.Framework;


namespace CompaniesHouse.IntegrationTests.Tests.PersonsWithSignificantControlTests
{
    [TestFixture]
    public class PersonsWithSignificantControlTestsInValid : PersonsWithSignificantControlTestBase
    {
        private const string InvalidCompanyNumber = "ABC00000";

        [SetUp]
        protected override async Task When()
        {
            await WhenRetrievingAnCompanyPersonsWithSignificantControlForAnInvalidCompany().ConfigureAwait(false);
        }


        [Test]
        public void ThenTheDataIsFullWithEmptyProperties()
        {
            Assert.That(_result.Data.Items, Is.Empty);
            Assert.That(_result.Data.ActiveCount, Is.EqualTo(0));
            Assert.That(_result.Data.CeasedCount, Is.EqualTo(0));
        }

        private async Task WhenRetrievingAnCompanyPersonsWithSignificantControlForAnInvalidCompany()
        {
            _result = await _client.GetPersonsWithSignificantControlAsync(InvalidCompanyNumber).ConfigureAwait(false);
        }
    }
}
