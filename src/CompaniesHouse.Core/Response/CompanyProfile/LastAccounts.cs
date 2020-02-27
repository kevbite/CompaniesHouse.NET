using System;
using CompaniesHouse.JsonConverters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CompaniesHouse.Response.CompanyProfile
{
    public class LastAccounts
    {
        [JsonProperty(PropertyName = "made_up_to")]
        [Obsolete("Deprecated - use PeriodEndOn")]
        public DateTime? MadeUpTo { get; set; }

        [JsonProperty(PropertyName = "period_end_on")]
        [JsonConverter(typeof(OptionalDateJsonConverter))]
        public DateTime? PeriodEndOn { get; set; }

        [JsonProperty(PropertyName = "period_start_on")]
        [JsonConverter(typeof(OptionalDateJsonConverter))]
        public DateTime? PeriodStartOn { get; set; }

        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public LastAccountsType Type { get; set; }
    }
}