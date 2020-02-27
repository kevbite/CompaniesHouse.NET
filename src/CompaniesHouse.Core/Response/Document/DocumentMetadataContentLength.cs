using Newtonsoft.Json;

namespace CompaniesHouse.Core.Response.Document
{
    public class DocumentMetadataContentLength
    {
        [JsonProperty("content_length")]
        public int ContentLength { get; set; }
    }
}