using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Insolvency
{
    public class CompanyInsolvencyInformation
    {
        [JsonPropertyName("cases")]
        public Case[] Cases { get; set; }

        [JsonPropertyName("etag")]
        public string Etag { get; set; }

        [JsonPropertyName("status")]
        public InsolvencyStatus[] Status { get; set; }
    }
}
