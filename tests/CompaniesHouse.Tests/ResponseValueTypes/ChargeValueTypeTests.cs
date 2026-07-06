using System.Text.Json;
using CompaniesHouse.Response;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.ResponseValueTypes
{
    public class ChargeValueTypeTests
    {
        [Theory]
        [InlineData(typeof(ChargeStatus), "outstanding")]
        [InlineData(typeof(ClassificationChargeType), "charge-description")]
        [InlineData(typeof(ParticularType), "brief-description")]
        [InlineData(typeof(SecuredDetailType), "amount-secured")]
        [InlineData(typeof(AssetsCeasedReleased), "whole-property-released")]
        public void KnownValues_RoundTrip(Type type, string wireValue)
        {
            var json = $"\"{wireValue}\"";
            var value = JsonSerializer.Deserialize(json, type, CompaniesHouseJsonSerializerOptions.Default);
            var serialized = JsonSerializer.Serialize(value, type, CompaniesHouseJsonSerializerOptions.Default);

            serialized.ShouldBe(json);
            type.GetProperty("Value")!.GetValue(value).ShouldBe(wireValue);
        }
    }
}
