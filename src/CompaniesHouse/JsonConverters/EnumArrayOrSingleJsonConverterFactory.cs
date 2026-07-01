using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CompaniesHouse.JsonConverters
{
    /// <summary>
    /// Reads an enum array property that the Companies House API sometimes returns as a single
    /// string instead of an array (e.g. filing history <c>subcategory</c>). Replaces the old
    /// custom string-or-array enum converter. Registered globally so no
    /// per-property <c>[JsonConverter]</c> attribute is required.
    /// </summary>
    public sealed class EnumArrayOrSingleJsonConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeToConvert.IsArray && typeToConvert.GetElementType() is { IsEnum: true };

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var elementType = typeToConvert.GetElementType()!;
            var converterType = typeof(EnumArrayOrSingleJsonConverter<>).MakeGenericType(elementType);
            return (JsonConverter)Activator.CreateInstance(converterType)!;
        }

        private sealed class EnumArrayOrSingleJsonConverter<TEnum> : JsonConverter<TEnum[]>
            where TEnum : struct, Enum
        {
            public override TEnum[]? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Null)
                {
                    return null;
                }

                if (reader.TokenType == JsonTokenType.StartArray)
                {
                    var items = new System.Collections.Generic.List<TEnum>();

                    while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                    {
                        items.Add(JsonSerializer.Deserialize<TEnum>(ref reader, options));
                    }

                    return items.ToArray();
                }

                var value = JsonSerializer.Deserialize<TEnum>(ref reader, options);
                return new[] { value };
            }

            public override void Write(Utf8JsonWriter writer, TEnum[] value, JsonSerializerOptions options)
            {
                writer.WriteStartArray();

                foreach (var item in value)
                {
                    JsonSerializer.Serialize(writer, item, options);
                }

                writer.WriteEndArray();
            }
        }
    }
}
