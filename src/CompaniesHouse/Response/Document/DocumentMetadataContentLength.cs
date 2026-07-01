using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Document
{
    public class DocumentMetadataContentLength
    {
        [JsonPropertyName("content_length")]
        public int ContentLength { get; set; }
    }
}
