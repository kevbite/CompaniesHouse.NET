using System;
using CompaniesHouse.Description;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.CompanyFiling
{
    public class FilingHistoryItemAnnotation : IDescriptable
    {
        [JsonPropertyName("annotation")]
        public string? Annotation { get; set; }

        [JsonPropertyName("date")]
        public DateTime? DateOfAnnotation { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonInclude]
        [JsonPropertyName("description_values")]
        private JsonElement? DescriptionValues { get; set; }

        public string GetDescription(string format)
        {
            return DescriptionProvider.GetDescription(format, DescriptionValues);
        }
    }
}
