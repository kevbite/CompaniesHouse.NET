using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.ChargesTests
{
    public class ChargesListTestsValid
    {
        private readonly CompaniesHouseClient _client;

        public ChargesListTestsValid()
        {
            _client = new CompaniesHouseClient(new CompaniesHouseSettings(CompaniesHouseUris.Default, Keys.ApiKey));
        }

        [Theory]
        [InlineData("03977902")]
        [InlineData("00445790")]
        [InlineData("00002065")]
        [InlineData("03487070")]
        public async Task ThenChargesListIsNotEmpty(string companyNumber)
        {
            var result = await _client.GetChargesListAsync(companyNumber);

            result.Data.Items.ShouldNotBeEmpty();
        }

        [Fact]
        public async Task ThenKnownChargeListIncludesObservedGeneratedValues()
        {
            var result = await _client.GetChargesListAsync("03977902");

            result.Data.UnfilteredCount.ShouldNotBeNull();
            result.Data.UnfilteredCount.Value.ShouldBeGreaterThan(0);
            result.Data.Items[0].Status.Value.ShouldNotBeNullOrWhiteSpace();
            result.Data.Items[0].Links?.Self.ShouldNotBeNullOrWhiteSpace();
        }
    }
}