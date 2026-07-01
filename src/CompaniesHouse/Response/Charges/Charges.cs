using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Charges
{
    public class Charges
    {
        [JsonPropertyName("Etag")]
        public string Etag { get; set; }
        
        [JsonPropertyName("items")]
        public Charge[] Items { get; set; }
        
        [JsonPropertyName("part_satisfied_count")]
        public int? PartSatisfiedCount { get; set; }
        
        [JsonPropertyName("satisfied_count")]
        public int? SatisfiedCount { get; set; }
        
        [JsonPropertyName("total_count")]
        public int? TotalCount { get; set; }
        
        [JsonPropertyName("unfiletered_count")]
        public int? UnfileteredCount { get; set; }
    }
}
