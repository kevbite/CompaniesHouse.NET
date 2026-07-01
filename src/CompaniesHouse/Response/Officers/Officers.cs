using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Officers
{
    public class Officers
    {
        [JsonPropertyName("active_count")]
        public int? ActiveCount { get; set; }

        [JsonPropertyName("items")]
        public Officer[] Items { get; set; }

        [JsonPropertyName("resigned_count")]
        public int? ResignedCount { get; set; }
        
        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
        
        [JsonPropertyName("start_index")]
        public int StartIndex { get; set; }
    }
}
