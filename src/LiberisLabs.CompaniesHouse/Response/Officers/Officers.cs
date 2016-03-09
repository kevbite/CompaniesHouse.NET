using LiberisLabs.CompaniesHouse.Response.CompanyProfile;
using Newtonsoft.Json;

namespace LiberisLabs.CompaniesHouse.Response.Officers
{
    public class Officers
    {
        [JsonProperty(PropertyName = "active_count")]
        public int? ActiveCount { get; set; }

        [JsonProperty(PropertyName = "items")]
        public Officer[] Items { get; set; }

        [JsonProperty(PropertyName = "resigned_count")]
        public int? ResignedCount { get; set; }
    }
}