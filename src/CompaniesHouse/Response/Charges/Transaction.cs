using System;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Charges
{
    public class Transaction
    {
        [JsonPropertyName("delivered_on")]
        public DateTime? DeliveredOn { get; set; }

        [JsonPropertyName("filing_type")]
        public string? FilingType { get; set; }

        [JsonPropertyName("insolvency_case_number")]
        public int? InsolvencyCaseNumber { get; set; }

        [JsonPropertyName("links")]
        public TransactionLinks? Links { get; set; }

        [JsonPropertyName("transaction_id")]
        public long? TransactionId { get; set; }
    }
}
