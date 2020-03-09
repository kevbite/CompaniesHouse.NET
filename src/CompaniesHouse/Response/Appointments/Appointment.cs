using System;
using CompaniesHouse.Response.Officers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CompaniesHouse.Response.Appointments
{
    public class Appointment
    {
        [JsonProperty(PropertyName = "officer_role")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OfficerRole OfficerRole { get; set; }

        [JsonProperty(PropertyName = "name_elements")]
        public NameElements NameElements { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "appointed_to")]
        public AppointedTo Appointed { get; set; }

        [JsonProperty(PropertyName = "nationality")]
        public string Nationality { get; set; }

        [JsonProperty(PropertyName = "country_of_residence")]
        public string CountryOfResidence { get; set; }

        [JsonProperty(PropertyName = "occupation")]
        public string Occupation { get; set; }

        [JsonProperty(PropertyName = "address")]
        public Address Address { get; set; }

        [JsonProperty(PropertyName = "appointed_on")]
        public DateTime? AppointedOn { get; set; }

        [JsonProperty(PropertyName = "resigned_on")]
        public DateTime? ResignedOn { get; set; }
    }
}