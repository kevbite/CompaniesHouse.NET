using System;
using CompaniesHouse.JsonConverters;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.CompanyProfile
{
    public class Accounts
    {
        [JsonPropertyName("accounting_reference_date")]
        public AccountingReferenceDate? AccountingReferenceDate { get; set; }

        [JsonPropertyName("last_accounts")]
        public LastAccounts? LastAccounts { get; set; }

        [JsonPropertyName("next_accounts")]
        public NextAccounts? NextAccounts { get; set; }

        [JsonPropertyName("next_due")]
        [JsonConverter(typeof(OptionalDateJsonConverter))]
        [Obsolete("Deprecated - use NextAccounts.DueOn")]
        public DateTime? NextDue { get; set; }

        [JsonPropertyName("next_made_up_to")]
        [Obsolete("Deprecated - use NextAccounts.PeriodEndOn")]
        public DateTime? NextMadeUpTo { get; set; }

        [JsonPropertyName("overdue")]
        [Obsolete("Deprecated - use NextAccounts.Overdue")]
        public bool? Overdue { get; set; }
    }
}
