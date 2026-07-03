using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Search.DissolvedCompaniesSearch
{
    public class DissolvedCompaniesSearch
    {
        [JsonPropertyName("etag")]
        public string? ETag { get; set; }

        [JsonPropertyName("hits")]
        public int? Hits { get; set; }

        [JsonPropertyName("items")]
        public Company[]? Items { get; set; }

        [JsonPropertyName("kind")]
        public string? Kind { get; set; }

        [JsonPropertyName("top_hit")]
        public Company? TopHit { get; set; }
    }
}
