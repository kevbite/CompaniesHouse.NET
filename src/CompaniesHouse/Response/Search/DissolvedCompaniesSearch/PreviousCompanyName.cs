using System;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Search.DissolvedCompaniesSearch
{
    public class PreviousCompanyName
    {
        [JsonPropertyName("ceased_on")]
        public DateTime? CeasedOn { get; set; }

        [JsonPropertyName("company_number")]
        public string CompanyNumber { get; set; } = null!;

        [JsonPropertyName("effective_from")]
        public DateTime? EffectiveFrom { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;
    }
}
