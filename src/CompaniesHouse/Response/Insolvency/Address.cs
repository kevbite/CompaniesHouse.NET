using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Insolvency
{
    public class Address
    {
        [JsonPropertyName("address_line_1")]
        public string? AddressLine1 { get; set; }

        [JsonPropertyName("address_line_2")]
        public string? AddressLine2 { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("locality")]
        public string? Locality { get; set; }

        [JsonPropertyName("postal_code")]
        public string? PostalCode { get; set; }

        [JsonPropertyName("region")]
        public string? Region { get; set; }
    }
}
