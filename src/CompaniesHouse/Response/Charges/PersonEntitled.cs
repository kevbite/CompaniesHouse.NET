using Newtonsoft.Json;

namespace CompaniesHouse.Response.Charges
{
    public class PersonEntitled
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}