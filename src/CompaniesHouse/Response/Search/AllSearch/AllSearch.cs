using CompaniesHouse.JsonConverters;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Search.AllSearch
{
    public class AllSearch
    {
        [JsonPropertyName("etag")]
        public string? Etag { get; set; }

        [JsonPropertyName("items")]
        public SearchItem[]? Items { get; set; }

        [JsonPropertyName("items_per_page")]
        public int? ItemsPerPage { get; set; }

        [JsonPropertyName("kind")]
        public string? Kind { get; set; }

        [JsonPropertyName("page_number")]
        public int? PageNumber { get; set; }

        [JsonPropertyName("start_index")]
        public int? StartIndex { get; set; }

        [JsonPropertyName("total_results")]
        public int? TotalResults { get; set; }
    }
}
