using CompaniesHouse.JsonConverters;
using Newtonsoft.Json;

namespace CompaniesHouse.Response.Charges
{
    public class Particular
    {
        [JsonProperty("chargor_acting_as_bare_trustee")]
        public bool? ChargorActingAsBareTrustee { get; set; }

        [JsonProperty("contains_fixed_charge")]
        public bool? ContainsFixedCharge { get; set; }

        [JsonProperty("contains_floating_charge")]
        public bool? ContainsFloatingCharge { get; set; }

        [JsonProperty("contains_negative_pledge")]
        public bool? ContainsNegativePledge { get; set; }

        [JsonProperty("description")] 
        public string Description { get; set; }

        [JsonProperty("floating_charge_covers_all")]
        public bool? FloatingChargeCoversAll { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(OptionalStringEnumConverter<ParticularType>), ParticularType.None)]
        public ParticularType Type { get; set; }
    }
}