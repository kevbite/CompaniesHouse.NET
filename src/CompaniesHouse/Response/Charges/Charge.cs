using System;
using CompaniesHouse.JsonConverters;
using Newtonsoft.Json;

namespace CompaniesHouse.Response.Charges
{
    public class Charge
    {
        [JsonProperty("acquired_on")]
        public DateTime? AcquiredOn { get; set; }

        [JsonProperty("assets_ceased_released")]
        [JsonConverter(typeof(OptionalStringEnumConverter<AssetsCeasedReleased>), AssetsCeasedReleased.None)]
        public AssetsCeasedReleased AssetsCeasedReleased { get; set; }

        [JsonProperty("charge_code")]
        public string ChargeCode { get; set; }

        [JsonProperty("charge_number")]
        public int? ChargeNumber { get; set; }

        [JsonProperty("classification")]
        public Classification Classification { get; set; }

        [JsonProperty("covering_instrument_date")]
        public DateTime? CoveringInstrumentDate { get; set; }

        [JsonProperty("created_on")]
        public DateTime? CreatedOn { get; set; }

        [JsonProperty("delivered_on")]
        public DateTime? DeliveredOn { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("insolvency_cases")]
        public InsolvencyCase[] InsolvencyCases { get; set; }

        [JsonProperty("links")]
        public Links Links { get; set; }

        [JsonProperty("more_than_four_persons_entitled")]
        public bool? MoreThanFourPersonsEntitled { get; set; }

        [JsonProperty("particulars")]
        public Particular Particular { get; set; }

        [JsonProperty("persons_entitled")]
        public PersonEntitled[] PersonsEntitled { get; set; }

        [JsonProperty("resolved_on")]
        public DateTime? ResolvedOn { get; set; }

        [JsonProperty("satisfied_on")]
        public DateTime? SatisfiedOn { get; set; }

        [JsonProperty("scottish_alterations")]
        public ScottishAlterations ScottishAlterations { get; set; }

        [JsonProperty("secured_details")]
        public SecuredDetail SecuredDetail { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(OptionalStringEnumConverter<ChargeStatus>), ChargeStatus.None)]
        public ChargeStatus Status { get; set; }

        [JsonProperty("transactions")]
        public Transaction[] Transactions { get; set; }
    }
}