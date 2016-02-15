using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LiberisLabs.CompaniesHouse.Response.CompanyProfile
{
    public class LastAccounts
    {
        [JsonProperty(PropertyName = "made_up_to")]
        public DateTime? MadeUpTo { get; set; }

        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public LastAccountsType Type { get; set; }
    }
}