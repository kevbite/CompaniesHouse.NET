using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.DisqualifiedOfficers
{
    public class CorporateDisqualification
    {
        [JsonPropertyName("company_number")]
        public string? CompanyNumber { get; set; }

        [JsonPropertyName("country_of_registration")]
        public string? CountryOfRegistration { get; set; }

        [JsonPropertyName("etag")]
        public string Etag { get; set; } = string.Empty;

        [JsonPropertyName("kind")]
        public string Kind { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("links")]
        public DisqualificationLinks Links { get; set; } = new();

        [JsonPropertyName("disqualifications")]
        public DisqualificationCase[] Disqualifications { get; set; } = [];

        [JsonPropertyName("permissions_to_act")]
        public DisqualificationPermissionToAct[]? PermissionsToAct { get; set; }

        [JsonPropertyName("person_number")]
        public string? PersonNumber { get; set; }
    }
}
