using System.Text.Json;
using CompaniesHouse.Response;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.ResponseValueTypes
{
    public class FilingValueTypeTests
    {
        [Theory]
        [InlineData(typeof(FilingCategory), "mortgage")]
        [InlineData(typeof(FilingSubcategory), "create")]
        [InlineData(typeof(FilingHistoryStatus), "filing-history-available")]
        [InlineData(typeof(ResolutionCategory), "miscellaneous")]
        public void KnownValues_RoundTrip(Type type, string wireValue)
        {
            var json = $"\"{wireValue}\"";
            var value = JsonSerializer.Deserialize(json, type, CompaniesHouseJsonSerializerOptions.Default);
            var serialized = JsonSerializer.Serialize(value, type, CompaniesHouseJsonSerializerOptions.Default);

            serialized.ShouldBe(json);
            type.GetProperty("Value")!.GetValue(value).ShouldBe(wireValue);
        }

        [Fact]
        public void UnknownFilingSubcategory_DoesNotThrow()
        {
            var value = JsonSerializer.Deserialize<FilingSubcategory>("\"brand-new-subcategory\"", CompaniesHouseJsonSerializerOptions.Default);

            value.Value.ShouldBe("brand-new-subcategory");
            value.IsKnown.ShouldBeFalse();
        }
    }
}
