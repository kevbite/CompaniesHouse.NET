using System.Text.Json;
using CompaniesHouse.Response.Insolvency;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.ResponseValueTypes
{
    public class InsolvencyValueTypeTests
    {
        [Theory]
        [InlineData(typeof(InsolvencyStatus), "in-administration")]
        [InlineData(typeof(CaseDateType), "administration-started-on")]
        [InlineData(typeof(InsolvencyCaseType), "creditors-voluntary-liquidation")]
        public void KnownValues_RoundTrip(Type type, string wireValue)
        {
            var json = $"\"{wireValue}\"";
            var value = JsonSerializer.Deserialize(json, type, CompaniesHouseJsonSerializerOptions.Default);
            var serialized = JsonSerializer.Serialize(value, type, CompaniesHouseJsonSerializerOptions.Default);

            serialized.ShouldBe(json);
            type.GetProperty("Value")!.GetValue(value).ShouldBe(wireValue);
        }

        [Fact]
        public void InsolvencyCaseType_ExposesDescriptions()
        {
            InsolvencyCaseType.CreditorsVoluntaryLiquidation.Description.ShouldBe("Creditors voluntary liquidation");
        }
    }
}
