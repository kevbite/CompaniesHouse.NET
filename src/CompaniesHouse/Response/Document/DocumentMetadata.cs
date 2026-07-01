using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Document
{
    public class DocumentMetadata
    {
        [JsonPropertyName("company_number")]
        public string? CompanyNumber { get; set; }
        [JsonPropertyName("barcode")]
        public string? Barcode { get; set; }
        [JsonPropertyName("significant_date")]
        public DateTime? SignificantDate { get; set; }
        [JsonPropertyName("significant_date_type")]
        public string? SignificantDateType { get; set; }
        [JsonPropertyName("category")]
        public string? Category { get; set; }
        [JsonPropertyName("pages")]
        public int Pages { get; set; }
        [JsonPropertyName("filename")]
        public string? Filename { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; }
        [JsonPropertyName("etag")]
        public string? Etag { get; set; }
        [JsonPropertyName("links")]
        public Links? Links { get; set; }
        [JsonPropertyName("resources")]
        public Dictionary<string, DocumentMetadataContentLength>? Resources { get; set; }
    }
}
