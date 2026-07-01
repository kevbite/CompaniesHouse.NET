using System;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Officers
{
    public class Officer
    {
        [JsonPropertyName("appointed_on")]
        public DateTime? AppointedOn { get; set; }

        [JsonPropertyName("resigned_on")]
        public DateTime? ResignedOn { get; set; }

        [JsonPropertyName("date_of_birth")]
        public OfficerDateOfBirth DateOfBirth { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("officer_role")]
        public OfficerRole OfficerRole { get; set; }

        [JsonPropertyName("nationality")]
        public string Nationality { get; set; }

        [JsonPropertyName("occupation")]
        public string Occupation { get; set; }

        [JsonPropertyName("address")]
        public Address Address { get; set; }

        [JsonPropertyName("country_of_residence")]
        public string CountryOfResidence { get; set; }

        [JsonPropertyName("former_names")]
        public OfficerFormerName[] FormerNames { get; set; }

        [JsonPropertyName("identification")]
        public OfficerIdentification Identification { get; set; }

        [JsonPropertyName("links")]
        public OfficerLinks Links { get; set; }
    }
}
