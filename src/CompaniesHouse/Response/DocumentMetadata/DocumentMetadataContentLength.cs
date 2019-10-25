using Newtonsoft.Json;

namespace CompaniesHouse.Response.DocumentMetadata
{
    public class DocumentMetadataContentLength
    {
        [JsonProperty("content_length")]
        public int ContentLength { get; set; }
    }
}