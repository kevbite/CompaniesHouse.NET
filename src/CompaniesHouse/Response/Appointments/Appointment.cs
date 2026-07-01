using System;
using CompaniesHouse.Response.Officers;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Appointments
{
    public class Appointment
    {
        [JsonPropertyName("officer_role")]
        public OfficerRole OfficerRole { get; set; }

        [JsonPropertyName("name_elements")]
        public NameElements NameElements { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("appointed_to")]
        public AppointedTo Appointed { get; set; }

        [JsonPropertyName("nationality")]
        public string Nationality { get; set; }

        [JsonPropertyName("country_of_residence")]
        public string CountryOfResidence { get; set; }

        [JsonPropertyName("occupation")]
        public string Occupation { get; set; }

        [JsonPropertyName("address")]
        public Address Address { get; set; }

        [JsonPropertyName("appointed_on")]
        public DateTime? AppointedOn { get; set; }

        [JsonPropertyName("resigned_on")]
        public DateTime? ResignedOn { get; set; }
    }
}
