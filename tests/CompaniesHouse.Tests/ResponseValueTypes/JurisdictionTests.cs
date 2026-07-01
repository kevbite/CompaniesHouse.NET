using System.Text.Json;
using CompaniesHouse.Response.CompanyProfile;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.ResponseValueTypes
{
    public class JurisdictionTests
    {
        [Theory]
        [InlineData("england-wales")]
        [InlineData("wales")]
        [InlineData("scotland")]
        [InlineData("northern-ireland")]
        [InlineData("european-union")]
        [InlineData("united-kingdom")]
        [InlineData("england")]
        [InlineData("noneu")]
        public void Deserializing_KnownValue_RoundTripsAndIsKnown(string value)
        {
            var json = $"\"{value}\"";

            var jurisdiction = JsonSerializer.Deserialize<Jurisdiction>(json, CompaniesHouseJsonSerializerOptions.Default);

            jurisdiction.Value.ShouldBe(value);
            jurisdiction.IsKnown.ShouldBeTrue();
            jurisdiction.HasValue.ShouldBeTrue();
            JsonSerializer.Serialize(jurisdiction, CompaniesHouseJsonSerializerOptions.Default).ShouldBe(json);
        }

        [Fact]
        public void Deserializing_UnknownValue_DoesNotThrowAndPreservesRawValue()
        {
            const string json = "\"future-jurisdiction\"";

            var jurisdiction = JsonSerializer.Deserialize<Jurisdiction>(json, CompaniesHouseJsonSerializerOptions.Default);

            jurisdiction.Value.ShouldBe("future-jurisdiction");
            jurisdiction.IsKnown.ShouldBeFalse();
            jurisdiction.Description.ShouldBeNull();
        }

        [Fact]
        public void Deserializing_Null_ReturnsDefaultWithNoValue()
        {
            var jurisdiction = JsonSerializer.Deserialize<Jurisdiction>("null", CompaniesHouseJsonSerializerOptions.Default);

            jurisdiction.ShouldBe(default);
            jurisdiction.HasValue.ShouldBeFalse();
            jurisdiction.Value.ShouldBe(string.Empty);
        }

        [Fact]
        public void Description_ReturnsFriendlyTextForKnownValues()
        {
            Jurisdiction.EnglandWales.Description.ShouldBe("England/Wales");
            Jurisdiction.Noneu.Description.ShouldBe("Foreign (Non E.U.)");
        }
    }
}
