using CompaniesHouse.Response.Appointments;
using System;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.PersonsWithSignificantControl
{
    public class PersonWithSignificantControl
    {
        [JsonPropertyName("address")]
        public Address? Address { get; set; }

        [JsonPropertyName("ceased")]
        public bool? Ceased { get; set; }

        [JsonPropertyName("ceased_on")]
        public DateTime? CeasedOn { get; set; }

        [JsonPropertyName("country_of_residence")]
        public string? CountryOfResidence { get; set; }

        [JsonPropertyName("date_of_birth")]
        public DateOfBirth? DateOfBirth { get; set; }

        [JsonPropertyName("etag")]
        public string? ETag { get; set; }

        [JsonPropertyName("kind")]
        public PersonWithSignificantControlKind Kind { get; set; }

        [JsonPropertyName("links")]
        public PersonWithSignificantControlLinks? Links { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("name_elements")]
        public NameElements? NameElements { get; set; }

        [JsonPropertyName("nationality")]
        public string? Nationality { get; set; }

        [JsonPropertyName("natures_of_control")]
        public PersonWithSignificantControlNatureOfControl[]? NaturesOfControl { get; set; }

        [JsonPropertyName("notified_on")]
        public DateTime? NotifiedOn { get; set; }

        [JsonPropertyName("identification")]
        public PersonWithSignificantControlIdentification? Identification { get; set; }
    }
}
