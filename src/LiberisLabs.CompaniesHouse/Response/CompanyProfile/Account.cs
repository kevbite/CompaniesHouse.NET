using LiberisLabs.CompaniesHouse.JsonConverters;
using Newtonsoft.Json;
using System;

namespace LiberisLabs.CompaniesHouse.Response.CompanyProfile
{
    public class Account
    {
        [JsonProperty(PropertyName = "accounting_reference_date")]
        public AccountingReferenceDate ARD { get; set; }

        [JsonProperty(PropertyName = "last_accounts")]
        public LastAccounts LastAccounts { get; set; }

        [JsonProperty(PropertyName = "next_due")]
        [JsonConverter(typeof(OptionalDateJsonConverter))]
        public DateTime? NextDue { get; set; }

        [JsonProperty(PropertyName = "next_made_up_to")]
        public DateTime? NextMadeUpTo { get; set; }

        [JsonProperty(PropertyName = "overdue")]
        public bool? Overdue { get; set; }
    }
}