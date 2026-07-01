using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.CompanyProfileTests
{

    public class CompanyProfileTestsInvalid : CompanyProfileTestsBase
    {
        private const string InvalidCompanyNumber = "ABC00000";


        protected override async Task When()
        {
            await WhenRetrievingAnInvalidCompanyProfile()
                ;
        }

        [IntegrationFact]
        public void ThenTheProfileIsNotReturned()
        {
            _result.Data.ShouldBeNull();
            _result.StatusCode.ShouldBe(404);
        }

        private async Task WhenRetrievingAnInvalidCompanyProfile()
        {
            _result = await _client.GetCompanyProfileAsync(InvalidCompanyNumber)
                ;
        }
    }
}
