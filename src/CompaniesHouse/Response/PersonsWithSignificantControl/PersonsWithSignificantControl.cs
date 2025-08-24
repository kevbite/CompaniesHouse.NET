using Newtonsoft.Json;

namespace CompaniesHouse.Response.PersonsWithSignificantControl
{
    public class PersonsWithSignificantControl
    {
        [JsonProperty(PropertyName = "active_count")]
        public int? ActiveCount { get; set; }

        [JsonProperty(PropertyName = "items")]
        public PersonWithSignificantControl[] Items { get; set; }

        [JsonProperty(PropertyName = "ceased_count")]
        public int? CeasedCount { get; set; }
        
        [JsonProperty(PropertyName = "items_per_page")]
        public int ItemsPerPage { get; set; }
        
        [JsonProperty(PropertyName = "start_index")]
        public int StartIndex { get; set; }

        [JsonProperty(PropertyName = "total_results")]
        public int TotalResults { get; set; }
    }
}
