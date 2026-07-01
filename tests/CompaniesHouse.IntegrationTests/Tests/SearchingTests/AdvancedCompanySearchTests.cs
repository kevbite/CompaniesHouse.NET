using System.Threading.Tasks;
using CompaniesHouse.Request;
using CompaniesHouse.Response;
using System.Linq;
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

        [IntegrationFact]
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

        [IntegrationFact]
        public async Task ThenCompanySubtypeCanBeUsedAsALiveFilter()
        {
            var result = await _client.AdvancedCompanySearchAsync(new AdvancedCompanySearchRequest
            {
                CompanySubtypes = new[] { CompanySubtype.CommunityInterestCompany },
                Size = 10,
            });

            result.Data.ShouldNotBeNull();
            result.Data.Items.ShouldContain(x => x.CompanySubtype == CompanySubtype.CommunityInterestCompany);
        }

        [IntegrationFact]
        public async Task ThenLocationAndSicCodeFiltersCanBeUsedTogether()
        {
            var result = await _client.AdvancedCompanySearchAsync(new AdvancedCompanySearchRequest
            {
                CompanyStatuses = new[] { CompanyStatus.Active },
                Location = "Manchester",
                SicCodes = new[] { "62012" },
                Size = 10,
            });

            result.Data.ShouldNotBeNull();
            result.Data.Items.ShouldNotBeEmpty();
            result.Data.Items.ShouldContain(x => x.SicCodes != null && x.SicCodes.Contains("62012"));
        }
    }
}
