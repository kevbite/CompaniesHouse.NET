using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.CompanyProfileTests
{
    
    public class CompanyProfileTestsValid : CompanyProfileTestsBase
    {
        // Google UK company number, unlikely to go away soon
        private const string ValidCompanyNumber = "03977902";

        
        protected override async Task When()
        {
            await WhenRetrievingAValidCompanyProfile()
                ;
        }

        [Fact]
        public void ThenTheProfileIsReturned()
        {
            _result.Data.CompanyName.ShouldNotBeEmpty();
        }

        private async Task WhenRetrievingAValidCompanyProfile()
        {
            _result = await _client.GetCompanyProfileAsync(ValidCompanyNumber)
                ;
        }
    }
}
