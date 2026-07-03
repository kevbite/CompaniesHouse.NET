using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.PersonsWithSignificantControlTests
{

    public class PersonsWithSignificantControlTestsValid : PersonsWithSignificantControlTestBase
    {
        // Google UK company number, unlikely to go away soon
        private const string ValidCompanyNumber = "03977902";


        protected override async Task When()
        {
            await WhenRetrievingAnCompanyPersonsWithSignificantControlForAnValidCompany();
        }

        [IntegrationFact]
        public void ThenTheDataItemsAreNotEmpty()
        {
            _result.Data.Items.ShouldNotBeEmpty();
        }

        [IntegrationFact]
        public void ThenObservedCountsAndKindsAreReturned()
        {
            var items = _result.Data.Items ?? [];

            _result.Data.TotalResults.ShouldNotBeNull();
            _result.Data.TotalResults.Value.ShouldBeGreaterThan(0);
            items.ShouldNotBeEmpty();
            items[0].Kind.Value.ShouldNotBeNullOrWhiteSpace();
        }

        private async Task WhenRetrievingAnCompanyPersonsWithSignificantControlForAnValidCompany()
        {
            _result = await _client.GetPersonsWithSignificantControlAsync(ValidCompanyNumber);
        }
    }
}
