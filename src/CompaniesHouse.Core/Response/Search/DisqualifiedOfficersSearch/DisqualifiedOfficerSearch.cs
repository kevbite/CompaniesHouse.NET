using Newtonsoft.Json;

namespace CompaniesHouse.Response.Search.DisqualifiedOfficersSearch
{
    public class DisqualifiedOfficerSearch
    {
        [JsonProperty(PropertyName = "items")]
        public DisqualifiedOfficer[] DisqualifiedOfficers { get; set; }

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
