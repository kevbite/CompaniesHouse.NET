using System;
using CompaniesHouse.Description;
using CompaniesHouse.JsonConverters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace CompaniesHouse.Response.CompanyFiling
{
    public class FilingHistoryItemResolution : IDescriptable
    {
        [JsonProperty(PropertyName = "category")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ResolutionCategory Category { get; set; }

        [JsonProperty(PropertyName = "subcategory")]
        [JsonConverter(typeof(StringArrayOrFieldEnumConverter))]
        public FilingSubcategory[] Subcategory { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "document_id")]
        public string DocumentId { get; set; }

        [JsonProperty(PropertyName = "receive_date")]
        public DateTime? DateOfProcessing { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string ResolutionType { get; set; }

        [JsonProperty(PropertyName = "description_values")]
        private JObject DescriptionValues { get; set; }

        public string GetDescription(string format)
        {
            return DescriptionProvider.GetDescription(format, DescriptionValues);
        }
    }
}
