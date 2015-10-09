using Newtonsoft.Json;

namespace LiberisLabs.CompaniesHouse.Response.CompanySearch
{
    public class CompanySearch
    {
        [JsonProperty(PropertyName = "etag")]
        public string ETag { get; set; }

        [JsonProperty(PropertyName = "items")]
        public Company[] Companies { get; set; }

        [JsonProperty(PropertyName = "items_per_page")]
        public int? ItemsPerPage { get; set; }

        [JsonProperty(PropertyName = "kind")]
        public string Kind { get; set; }

        [JsonProperty(PropertyName = "page_number")]
        public int? PageNumber { get; set; }

        [JsonProperty(PropertyName = "start_index")]
        public int? StartIndex { get; set; }

        [JsonProperty(PropertyName = "total_results")]
        public int? TotalResults { get; set; }
    }
}