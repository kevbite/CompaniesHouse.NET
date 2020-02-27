using Newtonsoft.Json;

namespace CompaniesHouse.Response.Search.OfficerSearch
{

    public class OfficerSearch
    {
        [JsonProperty(PropertyName = "items")]
        public Officer[] Officers { get; set; }

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
