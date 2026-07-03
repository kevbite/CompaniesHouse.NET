using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Search.CompanySearch
{
    public class CompanySearch
    {
        [JsonPropertyName("etag")]
        public string ETag { get; set; } = null!;

        [JsonPropertyName("items")]
        public Company[] Companies { get; set; } = null!;

        [JsonPropertyName("items_per_page")]
        public int? ItemsPerPage { get; set; }

        [JsonPropertyName("kind")]
        public string Kind { get; set; } = null!;

        [JsonPropertyName("page_number")]
        public int? PageNumber { get; set; }

        [JsonPropertyName("start_index")]
        public int? StartIndex { get; set; }

        [JsonPropertyName("total_results")]
        public int? TotalResults { get; set; }
    }
}
