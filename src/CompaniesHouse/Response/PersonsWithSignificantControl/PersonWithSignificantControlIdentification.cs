using Newtonsoft.Json;

namespace CompaniesHouse.Response.PersonsWithSignificantControl
{
    public class PersonWithSignificantControlIdentification
    {
        [JsonProperty(PropertyName = "legal_authority")]
        public string LegalAuthority { get; set; }

        [JsonProperty(PropertyName = "legal_form")]
        public string LegalForm { get; set; }

        [JsonProperty(PropertyName = "place_registered")]
        public string PlaceRegistered { get; set; }

        [JsonProperty(PropertyName = "registration_number")]
        public string RegistrationNumber { get; set; }

        [JsonProperty("country_registered")] public string CountryRegistered { get; set; }
    }
}