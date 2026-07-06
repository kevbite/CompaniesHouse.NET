using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Charges
{
    public class ScottishAlterations
    {
        [JsonPropertyName("has_alterations_to_order")]
        public bool? HasAlterationsToOrder { get; set; }
        
        [JsonPropertyName("has_alterations_to_prohibitions")]
        public bool? HasAlterationsToProhibitions { get; set; }
        
        [JsonPropertyName("has_restricting_provisions")]
        public bool? HasRestrictingProvisions { get; set; }
    }
}
