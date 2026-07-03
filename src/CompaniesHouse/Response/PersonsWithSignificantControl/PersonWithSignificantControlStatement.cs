using System;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.PersonsWithSignificantControl
{
    public class PersonWithSignificantControlStatement
    {
        [JsonPropertyName("etag")]
        public string ETag { get; set; } = string.Empty;

        [JsonPropertyName("kind")]
        public string Kind { get; set; } = string.Empty;

        [JsonPropertyName("notified_on")]
        public DateTime NotifiedOn { get; set; }

        [JsonPropertyName("ceased_on")]
        public DateTime? CeasedOn { get; set; }

        [JsonPropertyName("restrictions_notice_withdrawal_reason")]
        public string? RestrictionsNoticeWithdrawalReason { get; set; }

        [JsonPropertyName("statement")]
        public string Statement { get; set; } = string.Empty;

        [JsonPropertyName("linked_psc_name")]
        public string? LinkedPscName { get; set; }

        [JsonPropertyName("links")]
        public PersonWithSignificantControlStatementLinks Links { get; set; } = new();
    }
}
