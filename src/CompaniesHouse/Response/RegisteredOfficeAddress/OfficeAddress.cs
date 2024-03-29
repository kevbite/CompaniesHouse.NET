using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CompaniesHouse.Response.RegisteredOfficeAddress
{
    public class OfficeAddress
    {
        [JsonProperty(PropertyName = "address_line_1")]
        public string AddressLine1 { get; set; }
        
        [JsonProperty(PropertyName = "address_line_2")]
        public string AddressLine2 { get; set; }
        
        [JsonProperty(PropertyName = "country")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OfficeAddressCountry Country { get; set; }
        
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; set; }
        
        [JsonProperty(PropertyName = "kind")]
        public string Kind { get; set; }
        
        [JsonProperty(PropertyName = "links")]
        public Links Links { get; set; }
        
        [JsonProperty(PropertyName = "locality")]
        public string Locality { get; set; }

        [JsonProperty(PropertyName = "po_box")]
        public string PoBox { get; set; }
        
        [JsonProperty(PropertyName = "postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty(PropertyName = "Premises")]
        public string Premises { get; set; }

        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }
    }
}