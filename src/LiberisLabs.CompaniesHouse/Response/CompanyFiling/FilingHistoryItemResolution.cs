using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LiberisLabs.CompaniesHouse.Response.CompanyFiling
{
    public class FilingHistoryItemResolution
    {
        [JsonProperty(PropertyName = "category")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ResolutionCategory Category { get; set; }

        [JsonProperty(PropertyName = "subcategory")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FilingSubcategory Subcategory { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "document_id")]
        public string DocumentId { get; set; }

        [JsonProperty(PropertyName = "receive_date")]
        public DateTime? DateOfProcessing { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string ResolutionType { get; set; }
    }
}
