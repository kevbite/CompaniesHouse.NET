using Newtonsoft.Json;

namespace CompaniesHouse.Response
{
    public class Address
    {
        [JsonProperty(PropertyName = "address_line_1")]
        public string AddressLine1 { get; set; }

        [JsonProperty(PropertyName = "address_line_2")]
        public string AddressLine2 { get; set; }

        [JsonProperty(PropertyName = "care_of")]
        public string CareOf { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

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