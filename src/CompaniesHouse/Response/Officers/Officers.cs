using Newtonsoft.Json;

namespace CompaniesHouse.Response.Officers
{
    public class Officers
    {
        [JsonProperty(PropertyName = "active_count")]
        public int? ActiveCount { get; set; }

        [JsonProperty(PropertyName = "items")]
        public Officer[] Items { get; set; }

        [JsonProperty(PropertyName = "resigned_count")]
        public int? ResignedCount { get; set; }
        
        [JsonProperty(PropertyName = "total_results")]
        public int TotalResults { get; set; }
        
        [JsonProperty(PropertyName = "start_index")]
        public int StartIndex { get; set; }
    }
}