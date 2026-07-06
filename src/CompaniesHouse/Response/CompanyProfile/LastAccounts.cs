using System;
using CompaniesHouse.JsonConverters;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.CompanyProfile
{
    public class LastAccounts
    {
        [JsonPropertyName("made_up_to")]
        [Obsolete("Deprecated - use PeriodEndOn")]
        public DateTime? MadeUpTo { get; set; }

        [JsonPropertyName("period_end_on")]
        [JsonConverter(typeof(OptionalDateJsonConverter))]
        public DateTime? PeriodEndOn { get; set; }

        [JsonPropertyName("period_start_on")]
        [JsonConverter(typeof(OptionalDateJsonConverter))]
        public DateTime? PeriodStartOn { get; set; }

        [JsonPropertyName("type")]
        public LastAccountsType Type { get; set; }
    }
}
