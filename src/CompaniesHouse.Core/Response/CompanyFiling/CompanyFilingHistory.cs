using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CompaniesHouse.Core.Response.CompanyFiling
{
    public class CompanyFilingHistory
    {
        [JsonProperty(PropertyName = "filing_history_status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FilingHistoryStatus HistoryStatus { get; set; }

        [JsonProperty(PropertyName = "etag")]
        public string ETag { get; set; }

        [JsonProperty(PropertyName = "total_count")]
        public int TotalCount { get; set; }

        [JsonProperty(PropertyName = "items_per_page")]
        public int ItemsPerPage { get; set; }

        [JsonProperty(PropertyName = "start_index")]
        public int StartIndex { get; set; }

        [JsonProperty(PropertyName = "items")]
        public FilingHistoryItem[] Items { get; set; }

        [JsonProperty(PropertyName = "kind")]
        public string Kind { get; set; }
    }
}
