using CompaniesHouse.JsonConverters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.CompanyProfile
{
    public class PreviousCompanyName
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("ceased_on")]
        public DateTime CeasedOn { get; set; }

        [JsonPropertyName("effective_from")]
        public DateTime EffectiveFrom { get; set; }
    }
}
