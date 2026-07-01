using System;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Insolvency
{
    public class Practitioner
    {
        [JsonPropertyName("address")]
        public Address Address { get; set; }

        [JsonPropertyName("appointed_on")]
        public DateTime AppointedOn { get; set; }

        [JsonPropertyName("ceased_to_act_on")]
        public DateTime CeasedToActOn { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }
    }
}
