using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using CompaniesHouse.Response;

namespace CompaniesHouse.JsonConverters
{
    /// <summary>
    /// Reads/writes a <see cref="CompanyStatus"/> as its raw wire string. Performs no
    /// validation or lookup — unrecognised values are preserved rather than rejected.
    /// </summary>
    public sealed class CompanyStatusJsonConverter : JsonConverter<CompanyStatus>
    {
        public override CompanyStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return default;
            }

            return new CompanyStatus(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, CompanyStatus value, JsonSerializerOptions options)
        {
            if (!value.HasValue)
            {
                writer.WriteNullValue();
                return;
            }

            writer.WriteStringValue(value.Value);
        }
    }
}
