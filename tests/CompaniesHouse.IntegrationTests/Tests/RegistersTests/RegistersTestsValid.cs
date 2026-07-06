using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace CompaniesHouse.IntegrationTests.Tests.RegistersTests
{
    public class RegistersTestsValid
    {
        private readonly CompaniesHouseClient _client;

        public RegistersTestsValid()
        {
            _client = new CompaniesHouseClient(new CompaniesHouseSettings(CompaniesHouseUris.Default, Keys.ApiKey));
        }

        [IntegrationFact]
        public async Task ThenKnownCompanyRegistersIncludesObservedLiveFields()
        {
            var result = await _client.GetCompanyRegistersAsync("10725338");

            result.Data.ShouldNotBeNull();
            result.Data.Kind.ShouldBe("registers");
            result.Data.Links.Self.ShouldBe("/company/10725338/registers");
            result.Data.Registers.Directors.ShouldNotBeNull();
            result.Data.Registers.Directors.Items.ShouldNotBeEmpty();
            result.Data.Registers.UsualResidentialAddress.ShouldNotBeNull();
            result.Data.Registers.UsualResidentialAddress.Items.ShouldNotBeEmpty();
        }
    }
}
