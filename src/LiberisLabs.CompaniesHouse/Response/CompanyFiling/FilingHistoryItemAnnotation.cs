using System;
using Newtonsoft.Json;

namespace LiberisLabs.CompaniesHouse.Response.CompanyFiling
{
    public class FilingHistoryItemAnnotation
    {
        [JsonProperty(PropertyName = "annotation")]
        public string Annotation { get; set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime? DateOfAnnotation { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}
