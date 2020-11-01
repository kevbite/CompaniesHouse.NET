using Newtonsoft.Json;

namespace CompaniesHouse.Response.Charges
{
    public class ScottishAlterations
    {
        [JsonProperty("has_alterations_to_order")]
        public bool? HasAlterationsToOrder { get; set; }
        
        [JsonProperty("has_alterations_to_prohibitions")]
        public bool? HasAlterationsToProhibitions { get; set; }
        
        [JsonProperty("has_restricting_provisions")]
        public bool? HasRestrictingProvisions { get; set; }
    }
}