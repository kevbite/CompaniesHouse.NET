using CompaniesHouse.JsonConverters;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.CompanyFiling
{
    public class CompanyFilingHistory
    {
        [JsonPropertyName("filing_history_status")]
        public FilingHistoryStatus HistoryStatus { get; set; }

        [JsonPropertyName("etag")]
        public string? ETag { get; set; }

        [JsonPropertyName("total_count")]
        public int TotalCount { get; set; }

        [JsonPropertyName("items_per_page")]
        public int ItemsPerPage { get; set; }

        [JsonPropertyName("start_index")]
        public int StartIndex { get; set; }

        [JsonPropertyName("items")]
        public FilingHistoryItem[]? Items { get; set; }

        [JsonPropertyName("kind")]
        public string? Kind { get; set; }
    }
}
