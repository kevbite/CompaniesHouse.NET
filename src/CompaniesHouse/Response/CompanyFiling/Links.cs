using Newtonsoft.Json;

namespace CompaniesHouse.Response.CompanyFiling
{
    public class Links
    {
        [JsonProperty(PropertyName = "self")]
        public string Self { get; set; }

        [JsonProperty(PropertyName = "document_metadata")]
        public string DocumentMetaData { get; set; }
    }
}