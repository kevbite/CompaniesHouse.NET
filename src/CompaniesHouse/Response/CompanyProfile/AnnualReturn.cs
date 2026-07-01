using System;
using CompaniesHouse.JsonConverters;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.CompanyProfile
{
    public class AnnualReturn
    {
        [JsonPropertyName("last_made_up_to")]
        [JsonConverter(typeof(OptionalDateJsonConverter))]
        public DateTime? LastMadeUpTo { get; set; }

        [JsonPropertyName("next_due")]
        public DateTime? NextDue { get; set; }

        [JsonPropertyName("next_made_up_to")]
        public DateTime? NextMadeUpTo { get; set; }

        [JsonPropertyName("overdue")]
        public bool? Overdue { get; set; }
    }
}
