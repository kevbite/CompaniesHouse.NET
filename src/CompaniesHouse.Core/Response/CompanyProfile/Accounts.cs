using Newtonsoft.Json;
using System;
using CompaniesHouse.Core.JsonConverters;

namespace CompaniesHouse.Core.Response.CompanyProfile
{
    public class Accounts
    {
        [JsonProperty(PropertyName = "accounting_reference_date")]
        public AccountingReferenceDate AccountingReferenceDate { get; set; }

        [JsonProperty(PropertyName = "last_accounts")]
        public LastAccounts LastAccounts { get; set; }

        [JsonProperty(PropertyName = "next_accounts")]
        public NextAccounts NextAccounts { get; set; }

        [JsonProperty(PropertyName = "next_due")]
        [JsonConverter(typeof(OptionalDateJsonConverter))]
        [Obsolete("Deprecated - use NextAccounts.DueOn")]
        public DateTime? NextDue { get; set; }

        [JsonProperty(PropertyName = "next_made_up_to")]
        [Obsolete("Deprecated - use NextAccounts.PeriodEndOn")]
        public DateTime? NextMadeUpTo { get; set; }

        [JsonProperty(PropertyName = "overdue")]
        [Obsolete("Deprecated - use NextAccounts.Overdue")]
        public bool? Overdue { get; set; }
    }
}