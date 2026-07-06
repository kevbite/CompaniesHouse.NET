using System;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.DisqualifiedOfficers
{
    public class NaturalDisqualification
    {
        [JsonPropertyName("date_of_birth")]
        public DateTime? DateOfBirth { get; set; }

        [JsonPropertyName("etag")]
        public string Etag { get; set; } = string.Empty;

        [JsonPropertyName("forename")]
        public string? Forename { get; set; }

        [JsonPropertyName("honours")]
        public string? Honours { get; set; }

        [JsonPropertyName("kind")]
        public string Kind { get; set; } = string.Empty;

        [JsonPropertyName("nationality")]
        public string? Nationality { get; set; }

        [JsonPropertyName("other_forenames")]
        public string? OtherForenames { get; set; }

        [JsonPropertyName("surname")]
        public string Surname { get; set; } = string.Empty;

        [JsonPropertyName("title")]
        public string? Title { get; set; }

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
