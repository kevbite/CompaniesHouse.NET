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

        [Fact]
        public void ThenTheDataItemsAreNotEmpty()
        {
            _result.Data.Items.ShouldNotBeEmpty();
        }

        [Fact]
        public void ThenObservedCountsAndKindsAreReturned()
        {
            _result.Data.TotalResults.ShouldNotBeNull();
            _result.Data.TotalResults.Value.ShouldBeGreaterThan(0);
            _result.Data.Items[0].Kind.Value.ShouldNotBeNullOrWhiteSpace();
        }

        private async Task WhenRetrievingAnCompanyPersonsWithSignificantControlForAnValidCompany()
        {
            _result = await _client.GetPersonsWithSignificantControlAsync(ValidCompanyNumber);
        }
    }
}
