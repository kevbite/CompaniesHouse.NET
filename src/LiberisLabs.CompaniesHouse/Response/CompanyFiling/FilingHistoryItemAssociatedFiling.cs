using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LiberisLabs.CompaniesHouse.Response.CompanyFiling
{
    public class FilingHistoryItemAssociatedFiling
    {
        [JsonProperty(PropertyName = "type")]
        public string FilingType { get; set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime? Date { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "description_values")]
        private Dictionary<string, dynamic> DescriptionValues { get; set; }
    }
}