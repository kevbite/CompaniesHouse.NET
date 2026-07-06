using System.Text.Json;
using CompaniesHouse.Response;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.ResponseValueTypes
{
    public class CompanyTypeTests
    {
        [Theory]
        [InlineData("private-unlimited")]
        [InlineData("protected-cell-company")]
        [InlineData("eeig-establishment")]
        [InlineData("registered-overseas-entity")]
        public void Deserializing_KnownValue_RoundTripsAndIsKnown(string value)
        {
            var json = $"\"{value}\"";

            var companyType = JsonSerializer.Deserialize<CompanyType>(json, CompaniesHouseJsonSerializerOptions.Default);

            companyType.Value.ShouldBe(value);
            companyType.IsKnown.ShouldBeTrue();
            companyType.HasValue.ShouldBeTrue();
            JsonSerializer.Serialize(companyType, CompaniesHouseJsonSerializerOptions.Default).ShouldBe(json);
        }

        [Fact]
        public void Deserializing_UnknownValue_DoesNotThrowAndPreservesRawValue()
        {
            const string json = "\"future-company-type\"";

            var companyType = JsonSerializer.Deserialize<CompanyType>(json, CompaniesHouseJsonSerializerOptions.Default);

            companyType.Value.ShouldBe("future-company-type");
            companyType.IsKnown.ShouldBeFalse();
            companyType.Description.ShouldBeNull();
        }

        [Fact]
        public void Deserializing_Null_ReturnsDefaultWithNoValue()
        {
            var companyType = JsonSerializer.Deserialize<CompanyType>("null", CompaniesHouseJsonSerializerOptions.Default);

            companyType.ShouldBe(default);
            companyType.HasValue.ShouldBeFalse();
            companyType.Value.ShouldBe(string.Empty);
        }

        [Fact]
        public void Description_ReturnsFriendlyTextForKnownValues()
        {
            CompanyType.ProtectedCellCompany.Description.ShouldBe("Protected cell company");
            CompanyType.EeigEstablishment.Description.ShouldBe("European Economic Interest Grouping Establishment (EEIG)");
        }
    }
}
