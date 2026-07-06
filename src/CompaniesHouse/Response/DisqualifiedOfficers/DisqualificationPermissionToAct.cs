using System;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.DisqualifiedOfficers
{
    public class DisqualificationPermissionToAct
    {
        [JsonPropertyName("company_names")]
        public string[]? CompanyNames { get; set; }

        [JsonPropertyName("court_name")]
        public string? CourtName { get; set; }

        [JsonPropertyName("expires_on")]
        public DateTime ExpiresOn { get; set; }

        [JsonPropertyName("granted_on")]
        public DateTime GrantedOn { get; set; }
    }
}
