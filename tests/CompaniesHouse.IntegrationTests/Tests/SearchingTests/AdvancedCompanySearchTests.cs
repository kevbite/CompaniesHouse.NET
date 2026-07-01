using System.Threading.Tasks;
using CompaniesHouse.Request;
using CompaniesHouse.Response;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.SearchingTests
{
    public class AdvancedCompanySearchTests
    {
        private readonly CompaniesHouseClient _client;

        public AdvancedCompanySearchTests()
        {
            _client = new CompaniesHouseClient(new CompaniesHouseSettings(Keys.ApiKey));
        }

        [Fact]
        public async Task ThenCompaniesAreReturned()
        {
            var result = await _client.AdvancedCompanySearchAsync(new AdvancedCompanySearchRequest
            {
                CompanyNameIncludes = "TESCO",
                CompanyStatuses = new[] { CompanyStatus.Active },
                Size = 25,
            });

            result.Data.ShouldNotBeNull();
            result.Data.Items.ShouldNotBeEmpty();
        }
    }
}
