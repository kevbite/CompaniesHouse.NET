using System.Text.Json;
using CompaniesHouse.Response.Officers;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.ResponseValueTypes
{
    public class IdentificationTypeTests
    {
        [Theory]
        [InlineData("non-eea")]
        [InlineData("eea")]
        [InlineData("uk-limited-company")]
        [InlineData("other-corporate-body-or-firm")]
        [InlineData("registered-overseas-entity-corporate-managing-officer")]
        [InlineData("limited-partnership-corporate-partner")]
        public void Deserializing_KnownValue_RoundTripsAndIsKnown(string value)
        {
            var json = $"\"{value}\"";

            var identificationType = JsonSerializer.Deserialize<IdentificationType>(json, CompaniesHouseJsonSerializerOptions.Default);

            identificationType.Value.ShouldBe(value);
            identificationType.IsKnown.ShouldBeTrue();
            identificationType.HasValue.ShouldBeTrue();

            var reserialized = JsonSerializer.Serialize(identificationType, CompaniesHouseJsonSerializerOptions.Default);
            reserialized.ShouldBe(json);
        }

        [Fact]
        public void Deserializing_UnknownValue_DoesNotThrowAndPreservesRawValue()
        {
            const string json = "\"some-brand-new-identification-type\"";

            var identificationType = JsonSerializer.Deserialize<IdentificationType>(json, CompaniesHouseJsonSerializerOptions.Default);

            identificationType.Value.ShouldBe("some-brand-new-identification-type");
            identificationType.IsKnown.ShouldBeFalse();
            identificationType.HasValue.ShouldBeTrue();
            identificationType.Description.ShouldBeNull();

            var reserialized = JsonSerializer.Serialize(identificationType, CompaniesHouseJsonSerializerOptions.Default);
            reserialized.ShouldBe(json);
        }

        [Fact]
        public void Deserializing_Null_ReturnsDefaultWithNoValue()
        {
            var identificationType = JsonSerializer.Deserialize<IdentificationType>("null", CompaniesHouseJsonSerializerOptions.Default);

            identificationType.ShouldBe(default);
            identificationType.HasValue.ShouldBeFalse();
            identificationType.Value.ShouldBe(string.Empty);
            identificationType.IsKnown.ShouldBeFalse();

            var reserialized = JsonSerializer.Serialize(identificationType, CompaniesHouseJsonSerializerOptions.Default);
            reserialized.ShouldBe("null");
        }

        [Fact]
        public void KnownValues_CompareEqualToStaticMembers()
        {
            new IdentificationType("uk-limited-company").ShouldBe(IdentificationType.UkLimitedCompany);
            new IdentificationType("non-eea").ShouldBe(IdentificationType.NonEea);

            (IdentificationType.UkLimitedCompany == new IdentificationType("uk-limited-company")).ShouldBeTrue();
            (IdentificationType.UkLimitedCompany == IdentificationType.Eea).ShouldBeFalse();
        }

        [Fact]
        public void SwitchExpression_MatchesOnKnownValues()
        {
            var identificationType = new IdentificationType("uk-limited-company");

            var description = identificationType switch
            {
                _ when identificationType == IdentificationType.UkLimitedCompany => "is a UK company",
                _ when identificationType == IdentificationType.NonEea => "is non-EEA",
                _ => "something else",
            };

            description.ShouldBe("is a UK company");
        }

        [Fact]
        public void Description_ReturnsFriendlyTextForKnownValues()
        {
            IdentificationType.NonEea.Description.ShouldBe("Non European Economic Area");
            IdentificationType.RegisteredOverseasEntityCorporateManagingOfficer.Description.ShouldBe("Corporate managing officer");
        }

        [Fact]
        public void ToString_ReturnsRawValue()
        {
            IdentificationType.UkLimitedCompany.ToString().ShouldBe("uk-limited-company");
            default(IdentificationType).ToString().ShouldBe(string.Empty);
        }
    }
}
