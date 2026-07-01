using System.Threading.Tasks;
using CompaniesHouse.Response.Officers;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.OfficerTests
{
    
    public class OfficersTestsInvalid : OfficersTestBase<Officers>
    {
        private const string InvalidCompanyNumber = "ABC00000";

        
        protected override async Task When()
        {
            await WhenRetrievingAnCompanyFilingHistoryForAnInvalidCompany();
        }

        [Fact]
        public void ThenTheDataItemsAreEmpty()
        {
            // The Companies House API returns 200 with an empty officer list for a
            // malformed/non-existent company number rather than 404, so Data is
            // populated but contains no items.
            Result.Data.ShouldNotBeNull();
            Result.Data.Items.ShouldBeEmpty();
            Result.Data.TotalResults.ShouldBe(0);
        }

        private async Task WhenRetrievingAnCompanyFilingHistoryForAnInvalidCompany()
        {
            Result = await Client.GetOfficersAsync(InvalidCompanyNumber);
        }
    }
}
