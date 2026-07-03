using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Search.CompaniesAlphabeticallySearch
{
    public class CompaniesAlphabeticallySearch
    {
        [JsonPropertyName("items")]
        public Company[]? Items { get; set; }

        [JsonPropertyName("kind")]
        public string? Kind { get; set; }

        [JsonPropertyName("top_hit")]
        public Company? TopHit { get; set; }
    }
}
