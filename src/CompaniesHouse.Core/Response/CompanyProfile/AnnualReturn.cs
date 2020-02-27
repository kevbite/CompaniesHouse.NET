using System;
using CompaniesHouse.Core.JsonConverters;
using Newtonsoft.Json;

namespace CompaniesHouse.Core.Response.CompanyProfile
{
    public class AnnualReturn
    {
        [JsonProperty(PropertyName = "last_made_up_to")]
        [JsonConverter(typeof(OptionalDateJsonConverter))]
        public DateTime? LastMadeUpTo { get; set; }

        [JsonProperty(PropertyName = "next_due")]
        public DateTime? NextDue { get; set; }

        [JsonProperty(PropertyName = "next_made_up_to")]
        public DateTime? NextMadeUpTo { get; set; }

        [JsonProperty(PropertyName = "overdue")]
        public bool? Overdue { get; set; }
    }
}