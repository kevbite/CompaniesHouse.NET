using System;
using CompaniesHouse.Core.Description;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CompaniesHouse.Core.Response.CompanyFiling
{
    public class FilingHistoryItemAnnotation : IDescriptable
    {
        [JsonProperty(PropertyName = "annotation")]
        public string Annotation { get; set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime? DateOfAnnotation { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "description_values")]
        private JObject DescriptionValues { get; set; }

        public string GetDescription(string format)
        {
            return DescriptionProvider.GetDescription(format, DescriptionValues);
        }
    }
}
