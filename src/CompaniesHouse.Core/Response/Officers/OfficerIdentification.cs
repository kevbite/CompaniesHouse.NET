using Newtonsoft.Json;

namespace CompaniesHouse.Core.Response.Officers
{
    public class OfficerIdentification
    {
        [JsonProperty(PropertyName = "identification_type")]
        public string IdentificationType { get; set; }

        [JsonProperty(PropertyName = "legal_authority")]
        public string LegalAuthority { get; set; }

        [JsonProperty(PropertyName = "legal_form")]
        public string LegalForm { get; set; }

        [JsonProperty(PropertyName = "place_registered")]
        public string PlaceRegistered { get; set; }

        [JsonProperty(PropertyName = "registration_number")]
        public string RegistrationNumber { get; set; }
    }
}