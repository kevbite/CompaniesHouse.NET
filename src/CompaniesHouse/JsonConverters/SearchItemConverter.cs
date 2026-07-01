using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using CompaniesHouse.Response.Search;
using CompaniesHouse.Response.Search.CompanySearch;
using CompaniesHouse.Response.Search.DisqualifiedOfficersSearch;
using CompaniesHouse.Response.Search.OfficerSearch;

namespace CompaniesHouse.JsonConverters
{
    /// <summary>
    /// Polymorphic reader for <see cref="SearchItem"/>: picks the concrete type based on the
    /// "kind" discriminator field, mirroring the previous discriminator-based implementation.
    /// </summary>
    public class SearchItemConverter : JsonConverter<SearchItem>
    {
        public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(SearchItem);

        public override SearchItem Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var document = JsonDocument.ParseValue(ref reader);
            var root = document.RootElement;

            var kind = root.TryGetProperty("kind", out var kindElement) ? kindElement.GetString() : null;

            SearchItem item = kind switch
            {
                "searchresults#company" => root.Deserialize<Company>(options)!,
                "searchresults#officer" => root.Deserialize<Officer>(options)!,
                "searchresults#disqualified-officer" => root.Deserialize<DisqualifiedOfficer>(options)!,
                _ => throw new NotImplementedException($"Unknown search item kind \"{kind}\".")
            };

            return item;
        }

        public override void Write(Utf8JsonWriter writer, SearchItem value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}
