using System.Text.Json.Serialization;
using CompaniesHouse.Response.Officers;

namespace CompaniesHouse.Response.PersonsWithSignificantControl
{
    public class SuperSecurePersonWithSignificantControl
    {
        [JsonPropertyName("etag")]
        public string ETag { get; set; } = string.Empty;

        [JsonPropertyName("kind")]
        public string Kind { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("identity_verification_details")]
        public IdentityVerificationDetails? IdentityVerificationDetails { get; set; }

        [JsonPropertyName("ceased")]
        public bool? Ceased { get; set; }

        [JsonPropertyName("links")]
        public SuperSecurePersonWithSignificantControlLinks Links { get; set; } = new();
    }
}
