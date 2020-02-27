using Newtonsoft.Json;

namespace CompaniesHouse.Core.Response.Insolvency
{
    public class CompanyInsolvencyInformation
    {
        [JsonProperty("cases")]
        public Case[] Cases { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("status")]
        public InsolvencyStatus[] Status { get; set; }
    }
}
