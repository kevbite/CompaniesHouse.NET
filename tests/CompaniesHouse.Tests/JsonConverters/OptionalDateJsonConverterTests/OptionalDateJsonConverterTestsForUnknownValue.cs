using CompaniesHouse.JsonConverters;
using Moq;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.JsonConverters.OptionalDateJsonConverterTests
{
    public class OptionalDateJsonConverterTestsForUnknownValue
    {
        private OptionalDateJsonConverter _convertor;
        private object _result;

        public OptionalDateJsonConverterTestsForUnknownValue()
        {
            _convertor = new OptionalDateJsonConverter();
            var jsonReader = new Mock<JsonReader>();
            jsonReader.Setup(x => x.Value).Returns("Unknown");
            _result = _convertor.ReadJson(jsonReader.Object, null, null, null);
        }

        [Fact]
        public void ThenTheResultIsNull()
        {
            _result.ShouldBeNull();
        }
    }
}
