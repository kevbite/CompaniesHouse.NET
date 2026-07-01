using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.CompanyFiling
{
    public class Links
    {
        [JsonPropertyName("self")]
        public string? Self { get; set; }

        [JsonPropertyName("document_metadata")]
        public string? DocumentMetaData { get; set; }
    }
}
