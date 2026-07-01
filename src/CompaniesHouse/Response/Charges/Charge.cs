using System;
using CompaniesHouse.JsonConverters;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Charges
{
    public class Charge
    {
        [JsonPropertyName("acquired_on")]
        public DateTime? AcquiredOn { get; set; }

        [JsonPropertyName("assets_ceased_released")]
        public AssetsCeasedReleased AssetsCeasedReleased { get; set; }

        [JsonPropertyName("charge_code")]
        public string ChargeCode { get; set; }

        [JsonPropertyName("charge_number")]
        public int? ChargeNumber { get; set; }

        [JsonPropertyName("classification")]
        public Classification Classification { get; set; }

        [JsonPropertyName("covering_instrument_date")]
        public DateTime? CoveringInstrumentDate { get; set; }

        [JsonPropertyName("created_on")]
        public DateTime? CreatedOn { get; set; }

        [JsonPropertyName("delivered_on")]
        public DateTime? DeliveredOn { get; set; }

        [JsonPropertyName("etag")]
        public string Etag { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("insolvency_cases")]
        public InsolvencyCase[] InsolvencyCases { get; set; }

        [JsonPropertyName("links")]
        public Links Links { get; set; }

        [JsonPropertyName("more_than_four_persons_entitled")]
        public bool? MoreThanFourPersonsEntitled { get; set; }

        [JsonPropertyName("particulars")]
        public Particular Particular { get; set; }

        [JsonPropertyName("persons_entitled")]
        public PersonEntitled[] PersonsEntitled { get; set; }

        [JsonPropertyName("resolved_on")]
        public DateTime? ResolvedOn { get; set; }

        [JsonPropertyName("satisfied_on")]
        public DateTime? SatisfiedOn { get; set; }

        [JsonPropertyName("scottish_alterations")]
        public ScottishAlterations ScottishAlterations { get; set; }

        [JsonPropertyName("secured_details")]
        public SecuredDetail SecuredDetail { get; set; }

        [JsonPropertyName("status")]
        public ChargeStatus Status { get; set; }

        [JsonPropertyName("transactions")]
        public Transaction[] Transactions { get; set; }
    }
}
