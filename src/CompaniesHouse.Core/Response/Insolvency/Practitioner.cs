using System;
using Newtonsoft.Json;

namespace CompaniesHouse.Core.Response.Insolvency
{
    public class Practitioner
    {
        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("appointed_on")]
        public DateTime AppointedOn { get; set; }

        [JsonProperty("ceased_to_act_on")]
        public DateTime CeasedToActOn { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }
}