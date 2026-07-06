using CompaniesHouse.JsonConverters;
using System;
using System.Text;
using System.Text.Json;
using Shouldly;
using Xunit;

namespace CompaniesHouse.Tests.JsonConverters.OptionalDateJsonConverterTests
{
    public class OptionalDateJsonConverterTestsForUnknownValue
    {
        private readonly DateTime? _result;

        public OptionalDateJsonConverterTestsForUnknownValue()
        {
            var converter = new OptionalDateJsonConverter();
            var reader = new Utf8JsonReader(Encoding.UTF8.GetBytes(@"""Unknown"""));
            reader.Read();
            _result = converter.Read(ref reader, typeof(DateTime?), CompaniesHouseJsonSerializerOptions.Default);
        }

        [Fact]
        public void ThenTheResultIsNull()
        {
            _result.ShouldBeNull();
        }
    }
}
