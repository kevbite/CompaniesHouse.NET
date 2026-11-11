using System;
using System.Text.Json.Serialization;
using CompaniesHouse.Response.Appointments;
using CompaniesHouse.Response.Officers;

namespace CompaniesHouse.Response.PersonsWithSignificantControl
{
    public class PersonWithSignificantControlNotification
    {
        [JsonPropertyName("address")]
        public Address? Address { get; set; }

        [JsonPropertyName("ceased_on")]
        public DateTime? CeasedOn { get; set; }

        [JsonPropertyName("country_of_residence")]
        public string? CountryOfResidence { get; set; }

        [JsonPropertyName("etag")]
        public string? ETag { get; set; }

        [JsonPropertyName("identification")]
        public PersonWithSignificantControlIdentification? Identification { get; set; }

        [JsonPropertyName("identity_verification_details")]
        public IdentityVerificationDetails? IdentityVerificationDetails { get; set; }

        [JsonPropertyName("is_sanctioned")]
        public bool? IsSanctioned { get; set; }

        [JsonPropertyName("kind")]
        public PersonWithSignificantControlKind Kind { get; set; }

        [JsonPropertyName("links")]
        public PersonWithSignificantControlNotificationLinks? Links { get; set; }

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

        [JsonPropertyName("notified_to")]
        public PersonWithSignificantControlNotifiedTo? NotifiedTo { get; set; }

        [JsonPropertyName("principal_office_address")]
        public Address? PrincipalOfficeAddress { get; set; }
    }
}
