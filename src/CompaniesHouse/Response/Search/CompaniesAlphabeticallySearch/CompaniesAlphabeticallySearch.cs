using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Search.CompaniesAlphabeticallySearch
{
    public class CompaniesAlphabeticallySearch
    {
        [JsonPropertyName("items")]
        public Company[] Items { get; set; } = null!;

        [JsonPropertyName("kind")]
        public string Kind { get; set; } = null!;

        [JsonPropertyName("top_hit")]
        public Company TopHit { get; set; } = null!;
    }
}
