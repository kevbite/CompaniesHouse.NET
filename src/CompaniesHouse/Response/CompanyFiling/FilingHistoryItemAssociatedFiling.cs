using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.CompanyFiling
{
    public class FilingHistoryItemAssociatedFiling
    {
        [JsonPropertyName("type")]
        public string FilingType { get; set; }

        [JsonPropertyName("date")]
        public DateTime? Date { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("description_values")]
        private Dictionary<string, dynamic> DescriptionValues { get; set; }
    }
}
