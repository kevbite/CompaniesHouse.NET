using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Officers
{
    public class OfficerIdentification
    {
        [JsonPropertyName("identification_type")]
        public string IdentificationType { get; set; }

        [JsonPropertyName("legal_authority")]
        public string LegalAuthority { get; set; }

        [JsonPropertyName("legal_form")]
        public string LegalForm { get; set; }

        [JsonPropertyName("place_registered")]
        public string PlaceRegistered { get; set; }

        [JsonPropertyName("registration_number")]
        public string RegistrationNumber { get; set; }
    }
}
