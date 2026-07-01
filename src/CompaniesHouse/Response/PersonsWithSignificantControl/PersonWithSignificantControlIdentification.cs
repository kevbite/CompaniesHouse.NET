using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.PersonsWithSignificantControl
{
    public class PersonWithSignificantControlIdentification
    {
        [JsonPropertyName("legal_authority")]
        public string? LegalAuthority { get; set; }

        [JsonPropertyName("legal_form")]
        public string? LegalForm { get; set; }

        [JsonPropertyName("place_registered")]
        public string? PlaceRegistered { get; set; }

        [JsonPropertyName("registration_number")]
        public string? RegistrationNumber { get; set; }

        [JsonPropertyName("country_registered")]
        public string? CountryRegistered { get; set; }
    }
}
