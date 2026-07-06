using CompaniesHouse.JsonConverters;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Charges
{
    public class Particular
    {
        [JsonPropertyName("chargor_acting_as_bare_trustee")]
        public bool? ChargorActingAsBareTrustee { get; set; }

        [JsonPropertyName("contains_fixed_charge")]
        public bool? ContainsFixedCharge { get; set; }

        [JsonPropertyName("contains_floating_charge")]
        public bool? ContainsFloatingCharge { get; set; }

        [JsonPropertyName("contains_negative_pledge")]
        public bool? ContainsNegativePledge { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("floating_charge_covers_all")]
        public bool? FloatingChargeCoversAll { get; set; }

        [JsonPropertyName("type")]
        public ParticularType Type { get; set; }
    }
}
