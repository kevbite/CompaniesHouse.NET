using System;
using CompaniesHouse.Description;
using CompaniesHouse.JsonConverters;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.CompanyFiling
{
    public class FilingHistoryItem : IDescriptable
    {
        [JsonPropertyName("category")]
        public FilingCategory Category { get; set; }

        [JsonPropertyName("subcategory")]
        public FilingSubcategory[] Subcategory { get; set; } = null!;

        [JsonPropertyName("transaction_id")]
        public string? TransactionId { get; set; }

        [JsonPropertyName("type")]
        public string? FilingType { get; set; }

        [JsonPropertyName("barcode")]
        public string? Barcode { get; set; }

        [JsonPropertyName("date")]
        public DateTime? DateOfProcessing { get; set; }

        [JsonPropertyName("action_date")]
        public DateTime? ActionDate { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonInclude]
        [JsonPropertyName("description_values")]
        private JsonElement? DescriptionValues { get; set; }

        [JsonPropertyName("pages")]
        public int? PageCount { get; set; }

        [JsonPropertyName("paper_filed")]
        public bool? PaperFiled { get; set; }

        [JsonPropertyName("annotations")]
        public FilingHistoryItemAnnotation[]? Annotations { get; set; }

        [JsonPropertyName("associated_filings")]
        public FilingHistoryItemAssociatedFiling[]? AssociatedFilings { get; set; }

        [JsonPropertyName("resolutions")]
        public FilingHistoryItemResolution[]? Resolutions { get; set; }

        [JsonPropertyName("links")]
        public Links? Links { get; set; }

        public string GetDescription(string format)
        {
            return DescriptionProvider.GetDescription(format, DescriptionValues);
        }
    }
}
