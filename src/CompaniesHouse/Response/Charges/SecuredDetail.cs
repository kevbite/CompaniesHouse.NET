using CompaniesHouse.JsonConverters;
using Newtonsoft.Json;

namespace CompaniesHouse.Response.Charges
{
    public class SecuredDetail
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(OptionalStringEnumConverter<SecuredDetailType>), SecuredDetailType.None)]
        public SecuredDetailType Type { get; set; }
    }
}