using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace CompaniesHouse.Core.Response.Officers
{
    public class Officer
    {
        [JsonProperty(PropertyName = "appointed_on")]
        public DateTime? AppointedOn { get; set; }

        [JsonProperty(PropertyName = "resigned_on")]
        public DateTime? ResignedOn { get; set; }

        [JsonProperty(PropertyName = "date_of_birth")]
        public OfficerDateOfBirth DateOfBirth { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "officer_role")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OfficerRole OfficerRole { get; set; }

        [JsonProperty(PropertyName = "nationality")]
        public string Nationality { get; set; }

        [JsonProperty(PropertyName = "occupation")]
        public string Occupation { get; set; }

        [JsonProperty(PropertyName = "address")]
        public Address Address { get; set; }

        [JsonProperty(PropertyName = "country_of_residence")]
        public string CountryOfResidence { get; set; }

        [JsonProperty(PropertyName = "former_names")]
        public OfficerFormerName[] FormerNames { get; set; }

        [JsonProperty(PropertyName = "identification")]
        public OfficerIdentification Identification { get; set; }

        [JsonProperty(PropertyName = "links")]
        public OfficerLinks Links { get; set; }

        public string OfficerId {
            get
            {
                return Links.Officer.OfficerId;
            }
        }
    }
}