using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CompaniesHouse.Response.Insolvency
{
    public class CaseDate
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CaseDateType Type { get; set; }
    }
}