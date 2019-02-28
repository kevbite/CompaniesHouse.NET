using CompaniesHouse.JsonConverters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompaniesHouse.Response.CompanyProfile
{
    public class NextAccounts
    {
        [JsonProperty(PropertyName = "due_on")]
        [JsonConverter(typeof(OptionalDateJsonConverter))]
        public DateTime? DueOn { get; set; }

        [JsonProperty(PropertyName = "overdue")]
        public bool? Overdue { get; set; }

        [JsonProperty(PropertyName = "period_end_on")]
        [JsonConverter(typeof(OptionalDateJsonConverter))]
        public DateTime? PeriodEndOn { get; set; }

        [JsonProperty(PropertyName = "period_start_on")]
        [JsonConverter(typeof(OptionalDateJsonConverter))]
        public DateTime? PeriodStartOn { get; set; }
    }
}
