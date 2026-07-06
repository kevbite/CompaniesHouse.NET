using System;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Exemptions
{
    public class CompanyExemptionPeriod
    {
        [JsonPropertyName("exempt_from")]
        public DateTime ExemptFrom { get; set; }

        [JsonPropertyName("exempt_to")]
        public DateTime? ExemptTo { get; set; }
    }
}
