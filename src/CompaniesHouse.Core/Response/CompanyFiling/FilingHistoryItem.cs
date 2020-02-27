using System;
using CompaniesHouse.Core.Description;
using CompaniesHouse.Core.JsonConverters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace CompaniesHouse.Core.Response.CompanyFiling
{
    public class FilingHistoryItem : IDescriptable
    {
        [JsonProperty(PropertyName = "category")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FilingCategory Category { get; set; }

        [JsonProperty(PropertyName = "subcategory")]
        [JsonConverter(typeof(StringArrayOrFieldEnumConverter))]
        public FilingSubcategory[] Subcategory { get; set; }

        [JsonProperty(PropertyName = "transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string FilingType { get; set; }

        [JsonProperty(PropertyName = "barcode")]
        public string Barcode { get; set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime? DateOfProcessing { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "description_values")]
        private JObject DescriptionValues { get; set; }

        [JsonProperty(PropertyName = "pages")]
        public int? PageCount { get; set; }

        [JsonProperty(PropertyName = "paper_filed")]
        public bool? PaperFiled { get; set; }

        [JsonProperty(PropertyName = "annotations")]
        public FilingHistoryItemAnnotation[] Annotations { get; set; }

        [JsonProperty(PropertyName = "associated_filings")]
        public FilingHistoryItemAssociatedFiling[] AssociatedFilings { get; set; }

        [JsonProperty(PropertyName = "resolutions")]
        public FilingHistoryItemResolution[] Resolutions { get; set; }

        [JsonProperty(PropertyName = "links")]
        public Links Links { get; set; }

        public string GetDescription(string format)
        {
            return DescriptionProvider.GetDescription(format, DescriptionValues);
        }
    }
}
