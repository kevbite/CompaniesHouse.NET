using System.Threading.Tasks;
using CompaniesHouse.Response.UkEstablishments;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.UkEstablishmentsTests
{
    public class UkEstablishmentsTestsValid
    {
        private readonly CompaniesHouseClient _client;

        public UkEstablishmentsTestsValid()
        {
            _client = new CompaniesHouseClient(new CompaniesHouseSettings(Keys.ApiKey));
        }

        [IntegrationFact]
        public async Task ThenKnownForeignCompanyReturnsUkEstablishments()
        {
            var response = await _client.GetCompanyUkEstablishmentsAsync("FC040879");
            if (response is CompaniesHouseResponse<CompanyUkEstablishments>.RateLimited)
            {
                return;
            }

            var result = response.ShouldBeOfType<CompaniesHouseResponse<CompanyUkEstablishments>.Success>().Data;
            result.Kind.ShouldBe("related-companies");
            result.Links.Self.ShouldBe("/company/FC040879");
            result.Items.ShouldNotBeEmpty();
            result.Items[0].Links.Company.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
