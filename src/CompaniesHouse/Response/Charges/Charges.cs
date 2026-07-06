using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Charges
{
    public class Charges
    {
        [JsonPropertyName("etag")]
        public string? Etag { get; set; }

        [JsonPropertyName("items")]
        public Charge[]? Items { get; set; }

        [JsonPropertyName("part_satisfied_count")]
        public int? PartSatisfiedCount { get; set; }

        [JsonPropertyName("satisfied_count")]
        public int? SatisfiedCount { get; set; }

        [JsonPropertyName("total_count")]
        public int? TotalCount { get; set; }

        [JsonPropertyName("unfiltered_count")]
        public int? UnfilteredCount { get; set; }
    }
}
