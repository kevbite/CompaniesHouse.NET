using System.Text.Json;
using CompaniesHouse.Response.PersonsWithSignificantControl;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.ResponseValueTypes
{
    public class PscValueTypeTests
    {
        [Theory]
        [InlineData(typeof(PersonWithSignificantControlKind), "corporate-entity-person-with-significant-control")]
        [InlineData(typeof(PersonWithSignificantControlNatureOfControl), "right-to-appoint-and-remove-directors")]
        public void KnownValues_RoundTrip(Type type, string wireValue)
        {
            var json = $"\"{wireValue}\"";
            var value = JsonSerializer.Deserialize(json, type, CompaniesHouseJsonSerializerOptions.Default);
            var serialized = JsonSerializer.Serialize(value, type, CompaniesHouseJsonSerializerOptions.Default);

            serialized.ShouldBe(json);
            type.GetProperty("Value")!.GetValue(value).ShouldBe(wireValue);
        }

        [Fact]
        public void UnknownPscNatureOfControl_DoesNotThrow()
        {
            var value = JsonSerializer.Deserialize<PersonWithSignificantControlNatureOfControl>("\"brand-new-psc-nature\"", CompaniesHouseJsonSerializerOptions.Default);

            value.Value.ShouldBe("brand-new-psc-nature");
            value.IsKnown.ShouldBeFalse();
        }
    }
}
