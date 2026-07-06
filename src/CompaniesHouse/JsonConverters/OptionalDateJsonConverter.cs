using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CompaniesHouse.JsonConverters
{
    /// <summary>
    /// Handles Companies House dates that are sometimes returned as the literal string
    /// "Unknown" instead of a date, or as a partial date. Applied per-property (not every
    /// <c>DateTime?</c> needs this handling).
    /// </summary>
    public class OptionalDateJsonConverter : JsonConverter<DateTime?>
    {
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            var raw = reader.GetString();

            if (string.IsNullOrEmpty(raw) || raw == "Unknown")
            {
                return null;
            }

            return DateTime.Parse(raw);
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            if (value is null)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteStringValue(value.Value.ToString("yyyy-MM-dd"));
            }
        }
    }
}
