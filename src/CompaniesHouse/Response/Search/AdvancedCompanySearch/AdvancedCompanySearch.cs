using Newtonsoft.Json;

namespace CompaniesHouse.Response.Search.AdvancedCompanySearch
{
    public class AdvancedCompanySearch
    {
        [JsonProperty(PropertyName = "etag")]
        public string ETag { get; set; }

        [JsonProperty(PropertyName = "items")]
        public AdvancedSearchedCompany[] Companies { get; set; }

        [JsonProperty(PropertyName = "kind")]
        public string Kind { get; set; }

        [JsonProperty(PropertyName = "hits")]
        public int? Hits { get; set; }

        [JsonProperty(PropertyName = "top_hit")]
        public AdvancedSearchedCompany TopHit { get; set; }
    }
}