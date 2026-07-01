using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.RegisteredOfficeAddress
{
    public class OfficeAddress
    {
        [JsonPropertyName("address_line_1")]
        public string AddressLine1 { get; set; }
        
        [JsonPropertyName("address_line_2")]
        public string AddressLine2 { get; set; }
        
        [JsonPropertyName("country")]
        public OfficeAddressCountry Country { get; set; }
        
        [JsonPropertyName("etag")]
        public string Etag { get; set; }
        
        [JsonPropertyName("kind")]
        public string Kind { get; set; }
        
        [JsonPropertyName("links")]
        public Links Links { get; set; }
        
        [JsonPropertyName("locality")]
        public string Locality { get; set; }

        [JsonPropertyName("po_box")]
        public string PoBox { get; set; }
        
        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; }

        [JsonPropertyName("premises")]
        public string Premises { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }
    }
}
