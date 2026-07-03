using System.Threading.Tasks;
using CompaniesHouse.Response.Exemptions;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.ExemptionsTests
{
    public class ExemptionsTestsValid
    {
        private readonly CompaniesHouseClient _client;

        public ExemptionsTestsValid()
        {
            _client = new CompaniesHouseClient(new CompaniesHouseSettings(Keys.ApiKey));
        }

        [IntegrationFact]
        public async Task ThenKnownCompanyExemptionsAreReturned()
        {
            var response = await _client.GetCompanyExemptionsAsync("00445790");
            if (response is CompaniesHouseResponse<CompanyExemptions>.RateLimited)
            {
                return;
            }

            var result = response.ShouldBeOfType<CompaniesHouseResponse<CompanyExemptions>.Success>().Data;

            result.Kind.ShouldBe("exemptions");
            result.Links.Self.ShouldBe("/company/00445790/exemptions");
            result.Exemptions.PscExemptAsTradingOnUkRegulatedMarket.ShouldNotBeNull();
            result.Exemptions.PscExemptAsTradingOnUkRegulatedMarket.Items.ShouldNotBeEmpty();
        }
    }
}
