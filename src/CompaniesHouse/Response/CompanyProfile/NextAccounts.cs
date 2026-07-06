using CompaniesHouse.JsonConverters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.CompanyProfile
{
    public class NextAccounts
    {
        [JsonPropertyName("due_on")]
        [JsonConverter(typeof(OptionalDateJsonConverter))]
        public DateTime? DueOn { get; set; }

        [JsonPropertyName("overdue")]
        public bool? Overdue { get; set; }

        [JsonPropertyName("period_end_on")]
        [JsonConverter(typeof(OptionalDateJsonConverter))]
        public DateTime? PeriodEndOn { get; set; }

        [JsonPropertyName("period_start_on")]
        [JsonConverter(typeof(OptionalDateJsonConverter))]
        public DateTime? PeriodStartOn { get; set; }
    }
}
