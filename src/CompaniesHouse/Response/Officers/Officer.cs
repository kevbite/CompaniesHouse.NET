using System;
using System.Text.Json.Serialization;
using CompaniesHouse.JsonConverters;

namespace CompaniesHouse.Response.Officers
{
    public class Officer
    {
        [JsonPropertyName("etag")]
        public string? ETag { get; set; }

        [JsonPropertyName("appointed_on")]
        public DateTime? AppointedOn { get; set; }

        [JsonPropertyName("appointed_before")]
        [JsonConverter(typeof(OptionalDateJsonConverter))]
        public DateTime? AppointedBefore { get; set; }

        [JsonPropertyName("resigned_on")]
        public DateTime? ResignedOn { get; set; }

        [JsonPropertyName("date_of_birth")]
        public OfficerDateOfBirth? DateOfBirth { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("officer_role")]
        public OfficerRole OfficerRole { get; set; }

        [JsonPropertyName("nationality")]
        public string? Nationality { get; set; }

        [JsonPropertyName("occupation")]
        public string? Occupation { get; set; }

        [JsonPropertyName("address")]
        public Address? Address { get; set; }

        [JsonPropertyName("country_of_residence")]
        public string? CountryOfResidence { get; set; }

        [JsonPropertyName("former_names")]
        public OfficerFormerName[]? FormerNames { get; set; }

        [JsonPropertyName("identification")]
        public OfficerIdentification? Identification { get; set; }

        [JsonPropertyName("links")]
        public OfficerLinks? Links { get; set; }

        [JsonPropertyName("person_number")]
        public string? PersonNumber { get; set; }

        [JsonPropertyName("is_pre_1992_appointment")]
        public bool? IsPre1992Appointment { get; set; }

        [JsonPropertyName("identity_verification_details")]
        public IdentityVerificationDetails? IdentityVerificationDetails { get; set; }

        [JsonIgnore]
        public string? OfficerId => Links?.Officer?.OfficerId;
    }
}
