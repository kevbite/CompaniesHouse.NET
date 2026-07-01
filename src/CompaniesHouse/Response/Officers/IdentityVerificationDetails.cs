using System;
using System.Text.Json.Serialization;
using CompaniesHouse.JsonConverters;

namespace CompaniesHouse.Response.Officers
{
    public class IdentityVerificationDetails
    {
        [JsonPropertyName("anti_money_laundering_supervisory_bodies")]
        public string[]? AntiMoneyLaunderingSupervisoryBodies { get; set; }

        [JsonPropertyName("appointment_verification_end_on")]
        [JsonConverter(typeof(OptionalDateJsonConverter))]
        public DateTime? AppointmentVerificationEndOn { get; set; }

        [JsonPropertyName("appointment_verification_start_on")]
        [JsonConverter(typeof(OptionalDateJsonConverter))]
        public DateTime? AppointmentVerificationStartOn { get; set; }

        [JsonPropertyName("authorised_corporate_service_provider_name")]
        public string? AuthorisedCorporateServiceProviderName { get; set; }

        [JsonPropertyName("identity_verified_on")]
        [JsonConverter(typeof(OptionalDateJsonConverter))]
        public DateTime? IdentityVerifiedOn { get; set; }

        [JsonPropertyName("preferred_name")]
        public string? PreferredName { get; set; }
    }
}
