using Newtonsoft.Json;

namespace CompaniesHouse.Response.Document
{
    public class DocumentMetadataContentLength
    {
        [JsonProperty("content_length")]
        public int ContentLength { get; set; }
    }
}