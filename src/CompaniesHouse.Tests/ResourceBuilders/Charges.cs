using Newtonsoft.Json;

namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class Charges
    {
        [JsonProperty("Etag")]
        public string Etag { get; set; }
        
        [JsonProperty("items")]
        public Charge[] Items { get; set; }
        
        [JsonProperty("part_satisfied_count")]
        public int? PartSatisfiedCount { get; set; }
        
        [JsonProperty("satisfied_count")]
        public int? SatisfiedCount { get; set; }
        
        [JsonProperty("total_count")]
        public int? TotalCount { get; set; }
        
        [JsonProperty("unfiletered_count")]
        public int? UnfileteredCount { get; set; }
    }
}