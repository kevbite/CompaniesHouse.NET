using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CompaniesHouse.JsonConverters
{
    internal sealed class FlexibleBooleanJsonConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeToConvert == typeof(bool) || typeToConvert == typeof(bool?);

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options) =>
            typeToConvert == typeof(bool)
                ? new FlexibleBooleanJsonConverter()
                : new NullableFlexibleBooleanJsonConverter();

        private sealed class FlexibleBooleanJsonConverter : JsonConverter<bool>
        {
            public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.True)
                {
                    return true;
                }

                if (reader.TokenType == JsonTokenType.False)
                {
                    return false;
                }

                if (reader.TokenType == JsonTokenType.String && bool.TryParse(reader.GetString(), out var value))
                {
                    return value;
                }

                throw new JsonException("Unable to convert the JSON value to Boolean.");
            }

            public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options) =>
                writer.WriteBooleanValue(value);
        }

        private sealed class NullableFlexibleBooleanJsonConverter : JsonConverter<bool?>
        {
            public override bool? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Null)
                {
                    return null;
                }

                return new FlexibleBooleanJsonConverter().Read(ref reader, typeof(bool), options);
            }

            public override void Write(Utf8JsonWriter writer, bool? value, JsonSerializerOptions options)
            {
                if (value.HasValue)
                {
                    writer.WriteBooleanValue(value.Value);
                    return;
                }

                writer.WriteNullValue();
            }
        }
    }
}
