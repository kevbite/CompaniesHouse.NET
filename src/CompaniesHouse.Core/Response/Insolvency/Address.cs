using Newtonsoft.Json;

namespace CompaniesHouse.Response.Insolvency
{
    public class Address
    {
        [JsonProperty("address_line_1")]
        public string AddressLine1 { get; set; }

        [JsonProperty("address_line_2")]
        public string AddressLine2 { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("locality")]
        public string Locality { get; set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }
    }
}