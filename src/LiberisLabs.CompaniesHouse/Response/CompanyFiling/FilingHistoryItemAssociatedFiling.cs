using System;
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
    }
}