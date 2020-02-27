using CompaniesHouse.Core.JsonConverters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompaniesHouse.Core.Response.CompanyProfile
{
    public class PreviousCompanyName
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "ceased_on")]
        public DateTime CeasedOn { get; set; }

        [JsonProperty(PropertyName = "effective_from")]
        public DateTime EffectiveFrom { get; set; }
    }
}
