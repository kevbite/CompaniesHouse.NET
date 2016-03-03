using System;
using LiberisLabs.CompaniesHouse.Response.CompanySearch;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LiberisLabs.CompaniesHouse.Response.CompanyFiling
{
    public class FilingHistoryItem
    {
        [JsonProperty(PropertyName = "category")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FilingCategory Category { get; set; }

        [JsonProperty(PropertyName = "subcategory")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FilingSubcategory Subcategory { get; set; }

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
    }
}
