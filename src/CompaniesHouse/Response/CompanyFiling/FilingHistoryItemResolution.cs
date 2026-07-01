using System;
using CompaniesHouse.Description;
using CompaniesHouse.JsonConverters;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.CompanyFiling
{
    public class FilingHistoryItemResolution : IDescriptable
    {
        [JsonPropertyName("category")]
        public ResolutionCategory Category { get; set; }

        [JsonPropertyName("subcategory")]
        public FilingSubcategory[] Subcategory { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("document_id")]
        public string DocumentId { get; set; }

        [JsonPropertyName("receive_date")]
        public DateTime? DateOfProcessing { get; set; }

        [JsonPropertyName("type")]
        public string ResolutionType { get; set; }

        [JsonInclude]
        [JsonPropertyName("description_values")]
        private JsonElement? DescriptionValues { get; set; }

        public string GetDescription(string format)
        {
            return DescriptionProvider.GetDescription(format, DescriptionValues);
        }
    }
}
