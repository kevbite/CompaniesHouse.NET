using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LiberisLabs.CompaniesHouse.Response.CompanyFiling
{
    public class CompanyFilingHistory
    {
        [JsonProperty(PropertyName = "filing_history_status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public HistoryStatus HistoryStatus { get; set; }

        [JsonProperty(PropertyName = "etag")]
        public string ETag { get; set; }

        [JsonProperty(PropertyName = "total_count")]
        public int TotalCount { get; set; }

        [JsonProperty(PropertyName = "items_per_page")]
        public int ItemsPerPage { get; set; }

        [JsonProperty(PropertyName = "start_index")]
        public int StartIndex { get; set; }

        [JsonProperty(PropertyName = "items")]
        public HistoryItem[] Items { get; set; }
    }
}
