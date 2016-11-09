using Newtonsoft.Json;

namespace CompaniesHouse.Response.Insolvency
{
    public class Case
    {
        [JsonProperty("dates")]
        public CaseDate[] Dates { get; set; }

        [JsonProperty("links")]
        public Links Links { get; set; }

        [JsonProperty("notes")]
        public string[] Notes { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("practitioners")]
        public Practitioner[] Practitioners { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}