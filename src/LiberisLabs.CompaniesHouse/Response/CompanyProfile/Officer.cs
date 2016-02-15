using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LiberisLabs.CompaniesHouse.Response.CompanyProfile
{
    public class Officer
    {
        [JsonProperty(PropertyName = "appointed_on")]
        public DateTime? AppointedOn { get; set; }

        [JsonProperty(PropertyName = "date_of_birth")]
        public OfficerDateOfBirth DateOfBirth { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "officer_role")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OfficerRole OfficerRole { get; set; }
    }
}