using CompaniesHouse.JsonConverters;
using Newtonsoft.Json;

namespace CompaniesHouse.Response.Search.AllSearch
{
    public class AllSearch
    {
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; set; }

        [JsonProperty(PropertyName = "items")]
        public SearchItem[] Items { get; set; }

        [JsonProperty(PropertyName = "items_per_page")]
        public int ItemsPerPage { get; set; }

        [JsonProperty(PropertyName = "kind")]
        public string Kind { get; set; }

        [JsonProperty(PropertyName = "start_index")]
        public int StartIndex { get; set; }

        [JsonProperty(PropertyName = "total_results")]
        public int TotalResults { get; set; }
    }
}
