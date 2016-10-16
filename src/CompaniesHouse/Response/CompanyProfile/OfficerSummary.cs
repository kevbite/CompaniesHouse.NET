using Newtonsoft.Json;

namespace CompaniesHouse.Response.CompanyProfile
{
    public class OfficerSummary
    {
        [JsonProperty(PropertyName = "active_count")]
        public int? ActiveCount { get; set; }

        [JsonProperty(PropertyName = "officers")]
        public Officer[] Officers { get; set; }

        [JsonProperty(PropertyName = "resigned_count")]
        public int? ResignedCount { get; set; }
    }
}