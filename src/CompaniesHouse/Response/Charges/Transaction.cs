using System;
using Newtonsoft.Json;

namespace CompaniesHouse.Response.Charges
{
    public class Transaction
    {
        [JsonProperty("delivered_on")]
        public DateTime? DeliveredOn { get; set; }

        [JsonProperty("filing_type")]
        public string FilingType { get; set; }

        [JsonProperty("insolvency_case_number")]
        public int? InsolvencyCaseNumber { get; set; }

        [JsonProperty("links")]
        public TransactionLinks Links { get; set; }

        [JsonProperty("transaction_id")]
        public int? TransactionId { get; set; }
    }
}