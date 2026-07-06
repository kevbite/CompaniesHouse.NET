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
        public override bool CanConvert(Type typeToConvert)
        {
            if (!typeToConvert.IsArray)
            {
                return false;
            }

            var elementType = typeToConvert.GetElementType();
            if (elementType is null)
            {
                return false;
            }

            return elementType.IsEnum
                   || Attribute.IsDefined(elementType, typeof(JsonConverterAttribute), inherit: false);
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var elementType = typeToConvert.GetElementType()!;
            var converterType = typeof(EnumArrayOrSingleJsonConverter<>).MakeGenericType(elementType);
            return (JsonConverter)Activator.CreateInstance(converterType)!;
        }

        private sealed class EnumArrayOrSingleJsonConverter<TElement> : JsonConverter<TElement[]>
        {
            public override TElement[]? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Null)
                {
                    return null;
                }

                if (reader.TokenType == JsonTokenType.StartArray)
                {
                    var items = new System.Collections.Generic.List<TElement>();

                    while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                    {
                        items.Add(JsonSerializer.Deserialize<TElement>(ref reader, options)!);
                    }

                    return items.ToArray();
                }

                var value = JsonSerializer.Deserialize<TElement>(ref reader, options)!;
                return new[] { value };
            }

            public override void Write(Utf8JsonWriter writer, TElement[] value, JsonSerializerOptions options)
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
