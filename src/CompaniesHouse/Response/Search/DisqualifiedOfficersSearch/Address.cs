using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Search.DisqualifiedOfficersSearch
{
    public class Address
    {
        [JsonPropertyName("address_line_1")]
        public string AddressLine1 { get; set; } = null!;

        [JsonPropertyName("address_line_2")]
        public string AddressLine2 { get; set; } = null!;

        [JsonPropertyName("country")]
        public string Country { get; set; } = null!;

        [JsonPropertyName("locality")]
        public string Locality { get; set; } = null!;

        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; } = null!;

        [JsonPropertyName("premises")]
        public string Premises { get; set; } = null!;

        [JsonPropertyName("region")]
        public string Region { get; set; } = null!;
    }
}
