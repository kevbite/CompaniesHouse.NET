using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Officers
{
    public class Officers
    {
        [JsonPropertyName("etag")]
        public string ETag { get; set; } = string.Empty;

        [JsonPropertyName("active_count")]
        public int ActiveCount { get; set; }

        [JsonPropertyName("inactive_count")]
        public int? InactiveCount { get; set; }

        [JsonPropertyName("items")]
        public Officer[] Items { get; set; } = [];

        [JsonPropertyName("items_per_page")]
        public int ItemsPerPage { get; set; }

        [JsonPropertyName("kind")]
        public string Kind { get; set; } = string.Empty;

        [JsonPropertyName("links")]
        public OfficersListLinks Links { get; set; } = new();

        [JsonPropertyName("resigned_count")]
        public int ResignedCount { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }

        [JsonPropertyName("start_index")]
        public int StartIndex { get; set; }
    }
}
