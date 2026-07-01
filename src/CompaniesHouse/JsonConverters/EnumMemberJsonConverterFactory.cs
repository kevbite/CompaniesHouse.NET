using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CompaniesHouse.JsonConverters
{
    /// <summary>
    /// Converts C# enums decorated with <see cref="EnumMemberAttribute"/> to/from their wire
    /// string value, matching the previous string-enum wire format behaviour.
    /// Registered globally so no per-property <c>[JsonConverter]</c> attribute is required.
    /// </summary>
    public sealed class EnumMemberJsonConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert) => typeToConvert.IsEnum;

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var converterType = typeof(EnumMemberJsonConverter<>).MakeGenericType(typeToConvert);
            return (JsonConverter)Activator.CreateInstance(converterType)!;
        }

        private sealed class EnumMemberJsonConverter<TEnum> : JsonConverter<TEnum>
            where TEnum : struct, Enum
        {
            private static readonly Dictionary<string, TEnum> ValueToEnum = new(StringComparer.Ordinal);
            private static readonly Dictionary<TEnum, string> EnumToValue = new();

            static EnumMemberJsonConverter()
            {
                foreach (var field in typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static))
                {
                    var enumValue = (TEnum)field.GetValue(null)!;
                    var name = field.GetCustomAttribute<EnumMemberAttribute>()?.Value ?? field.Name;

                    ValueToEnum[name] = enumValue;
                    ValueToEnum[field.Name] = enumValue;
                    EnumToValue[enumValue] = name;
                }
            }

            public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Null)
                {
                    return default;
                }

                var raw = reader.GetString() ?? string.Empty;

                if (ValueToEnum.TryGetValue(raw, out var value))
                {
                    return value;
                }

                throw new JsonException($"Unable to convert \"{raw}\" to enum \"{typeof(TEnum).Name}\".");
            }

            public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(EnumToValue.TryGetValue(value, out var raw) ? raw : value.ToString());
            }
        }
    }
}
