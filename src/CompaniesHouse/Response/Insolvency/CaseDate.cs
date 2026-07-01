using System;
using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Insolvency
{
    public class CaseDate
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("type")]
        public CaseDateType Type { get; set; }
    }
}
