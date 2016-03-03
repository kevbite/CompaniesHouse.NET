using Newtonsoft.Json;

namespace LiberisLabs.CompaniesHouse.Response.CompanySearch
{
    public class Links
    {
        [JsonProperty(PropertyName = "self")]
        public string Self { get; set; }

        [JsonProperty(PropertyName = "document_metadata")]
        public string DocumentMetaData { get; set; }
    }
}