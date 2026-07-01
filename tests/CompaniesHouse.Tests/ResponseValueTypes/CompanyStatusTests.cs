using System.Text.Json;
using CompaniesHouse.Response;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.ResponseValueTypes
{
    public class CompanyStatusTests
    {
        [Theory]
        [InlineData("active")]
        [InlineData("dissolved")]
        [InlineData("liquidation")]
        [InlineData("receivership")]
        [InlineData("administration")]
        [InlineData("voluntary-arrangement")]
        [InlineData("converted-closed")]
        [InlineData("insolvency-proceedings")]
        [InlineData("open")]
        [InlineData("closed")]
        [InlineData("closed-on")]
        [InlineData("registered")]
        [InlineData("removed")]
        public void Deserializing_KnownValue_RoundTripsAndIsKnown(string value)
        {
            var json = $"\"{value}\"";

            var status = JsonSerializer.Deserialize<CompanyStatus>(json, CompaniesHouseJsonSerializerOptions.Default);

            status.Value.ShouldBe(value);
            status.IsKnown.ShouldBeTrue();
            status.HasValue.ShouldBeTrue();

            var reserialized = JsonSerializer.Serialize(status, CompaniesHouseJsonSerializerOptions.Default);
            reserialized.ShouldBe(json);
        }

        [Fact]
        public void Deserializing_UnknownValue_DoesNotThrowAndPreservesRawValue()
        {
            const string json = "\"some-brand-new-status-companies-house-invented-tomorrow\"";

            var status = JsonSerializer.Deserialize<CompanyStatus>(json, CompaniesHouseJsonSerializerOptions.Default);

            status.Value.ShouldBe("some-brand-new-status-companies-house-invented-tomorrow");
            status.IsKnown.ShouldBeFalse();
            status.HasValue.ShouldBeTrue();
            status.Description.ShouldBeNull();

            var reserialized = JsonSerializer.Serialize(status, CompaniesHouseJsonSerializerOptions.Default);
            reserialized.ShouldBe(json);
        }

        [Fact]
        public void Deserializing_Null_ReturnsDefaultWithNoValue()
        {
            var status = JsonSerializer.Deserialize<CompanyStatus>("null", CompaniesHouseJsonSerializerOptions.Default);

            status.ShouldBe(default);
            status.HasValue.ShouldBeFalse();
            status.Value.ShouldBe(string.Empty);
            status.IsKnown.ShouldBeFalse();

            var reserialized = JsonSerializer.Serialize(status, CompaniesHouseJsonSerializerOptions.Default);
            reserialized.ShouldBe("null");
        }

        [Fact]
        public void KnownValues_CompareEqualToStaticMembers()
        {
            new CompanyStatus("active").ShouldBe(CompanyStatus.Active);
            new CompanyStatus("dissolved").ShouldBe(CompanyStatus.Dissolved);
            new CompanyStatus("removed").ShouldBe(CompanyStatus.Removed);

            (CompanyStatus.Active == new CompanyStatus("active")).ShouldBeTrue();
            (CompanyStatus.Active == CompanyStatus.Dissolved).ShouldBeFalse();
        }

        [Fact]
        public void SwitchExpression_MatchesOnKnownValues()
        {
            var status = new CompanyStatus("dissolved");

            var description = status switch
            {
                _ when status == CompanyStatus.Active => "is active",
                _ when status == CompanyStatus.Dissolved => "is dissolved",
                _ => "something else",
            };

            description.ShouldBe("is dissolved");
        }

        [Fact]
        public void Description_ReturnsFriendlyTextForKnownValues()
        {
            CompanyStatus.Active.Description.ShouldBe("Active");
            CompanyStatus.InsolvencyProceedings.Description.ShouldBe("Insolvency Proceedings");
        }

        [Fact]
        public void ToString_ReturnsRawValue()
        {
            CompanyStatus.Active.ToString().ShouldBe("active");
            default(CompanyStatus).ToString().ShouldBe(string.Empty);
        }
    }
}
