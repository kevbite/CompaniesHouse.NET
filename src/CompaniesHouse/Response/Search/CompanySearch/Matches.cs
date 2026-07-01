using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Search.CompanySearch
{
    public class Matches
    {
        [JsonPropertyName("title")]
        public int[] Title { get; set; }
    }

}
