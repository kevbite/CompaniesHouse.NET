using System.Collections.Generic;
using Newtonsoft.Json;

namespace CompaniesHouse.Response.Document
{
    public class DocumentMetadata
    {
        [JsonProperty("company_number")]
        public string CompanyNumber { get; set; }
        [JsonProperty("barcode")]
        public string Barcode { get; set; }
        [JsonProperty("significant_date")]
        public object SignificantDate { get; set; }
        [JsonProperty("significant_date_type")]
        public string SignificantDateType { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("pages")]
        public int Pages { get; set; }
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
        [JsonProperty("etag")]
        public string Etag { get; set; }
        [JsonProperty("links")]
        public Links Links { get; set; }
        [JsonProperty("resources")]
        public Dictionary<string, DocumentMetadataContentLength> Resources { get; set; }
    }
}