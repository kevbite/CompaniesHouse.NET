using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Search.DissolvedCompaniesSearch
{
    public class DissolvedCompaniesSearch
    {
        [JsonPropertyName("etag")]
        public string ETag { get; set; } = null!;

        [JsonPropertyName("hits")]
        public int? Hits { get; set; }

        [JsonPropertyName("items")]
        public Company[] Items { get; set; } = null!;

        [JsonPropertyName("kind")]
        public string Kind { get; set; } = null!;

        [JsonPropertyName("top_hit")]
        public Company TopHit { get; set; } = null!;
    }
}
