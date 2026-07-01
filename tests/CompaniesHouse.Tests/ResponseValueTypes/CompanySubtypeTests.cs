using System.Text.Json;
using CompaniesHouse.Response;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.ResponseValueTypes
{
    public class CompanySubtypeTests
    {
        [Theory]
        [InlineData("community-interest-company")]
        [InlineData("private-fund-limited-partnership")]
        [InlineData("slp")]
        public void Deserializing_KnownValue_RoundTripsAndIsKnown(string value)
        {
            var json = $"\"{value}\"";

            var companySubtype = JsonSerializer.Deserialize<CompanySubtype>(json, CompaniesHouseJsonSerializerOptions.Default);

            companySubtype.Value.ShouldBe(value);
            companySubtype.IsKnown.ShouldBeTrue();
            companySubtype.HasValue.ShouldBeTrue();
            JsonSerializer.Serialize(companySubtype, CompaniesHouseJsonSerializerOptions.Default).ShouldBe(json);
        }

        [Fact]
        public void Deserializing_UnknownValue_DoesNotThrowAndPreservesRawValue()
        {
            const string json = "\"future-company-subtype\"";

            var companySubtype = JsonSerializer.Deserialize<CompanySubtype>(json, CompaniesHouseJsonSerializerOptions.Default);

            companySubtype.Value.ShouldBe("future-company-subtype");
            companySubtype.IsKnown.ShouldBeFalse();
            companySubtype.Description.ShouldBeNull();
        }

        [Fact]
        public void Description_ReturnsFriendlyTextForKnownValues()
        {
            CompanySubtype.CommunityInterestCompany.Description.ShouldBe("Community Interest Company (CIC)");
            CompanySubtype.PrivateFundLimitedPartnership.Description.ShouldBe("Private Fund Limited Partnership (PFLP)");
        }
    }
}
