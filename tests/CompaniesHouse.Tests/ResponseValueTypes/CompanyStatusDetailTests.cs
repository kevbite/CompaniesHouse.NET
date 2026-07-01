using System.Text.Json;
using CompaniesHouse.Response;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.ResponseValueTypes
{
    public class CompanyStatusDetailTests
    {
        [Theory]
        [InlineData("transferred-from-uk")]
        [InlineData("active-proposal-to-strike-off")]
        [InlineData("petition-to-restore-dissolved")]
        [InlineData("transformed-to-se")]
        [InlineData("converted-to-plc")]
        [InlineData("converted-to-ukeig")]
        [InlineData("converted-to-uk-societas")]
        public void Deserializing_KnownValue_RoundTripsAndIsKnown(string value)
        {
            var json = $"\"{value}\"";

            var statusDetail = JsonSerializer.Deserialize<CompanyStatusDetail>(json, CompaniesHouseJsonSerializerOptions.Default);

            statusDetail.Value.ShouldBe(value);
            statusDetail.IsKnown.ShouldBeTrue();
            statusDetail.HasValue.ShouldBeTrue();
            JsonSerializer.Serialize(statusDetail, CompaniesHouseJsonSerializerOptions.Default).ShouldBe(json);
        }

        [Fact]
        public void Deserializing_UnknownValue_DoesNotThrowAndPreservesRawValue()
        {
            const string json = "\"future-company-status-detail\"";

            var statusDetail = JsonSerializer.Deserialize<CompanyStatusDetail>(json, CompaniesHouseJsonSerializerOptions.Default);

            statusDetail.Value.ShouldBe("future-company-status-detail");
            statusDetail.IsKnown.ShouldBeFalse();
            statusDetail.Description.ShouldBeNull();
        }

        [Fact]
        public void Deserializing_Null_ReturnsDefaultWithNoValue()
        {
            var statusDetail = JsonSerializer.Deserialize<CompanyStatusDetail>("null", CompaniesHouseJsonSerializerOptions.Default);

            statusDetail.ShouldBe(default);
            statusDetail.HasValue.ShouldBeFalse();
            statusDetail.Value.ShouldBe(string.Empty);
        }

        [Fact]
        public void Description_ReturnsFriendlyTextForKnownValues()
        {
            CompanyStatusDetail.ActiveProposalToStrikeOff.Description.ShouldBe("Active proposal to strike off");
            CompanyStatusDetail.ConvertedToUkeig.Description.ShouldBe("Converted to UKEIG");
        }
    }
}
