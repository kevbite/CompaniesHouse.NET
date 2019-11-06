using Newtonsoft.Json;

namespace CompaniesHouse.Tests.ResourceBuilders
{
    public class PersonsWithSignificantControl
    {
        [JsonProperty(PropertyName = "active_count")]
        public int? ActiveCount { get; set; }

        [JsonProperty(PropertyName = "items")]
        public PersonWithSignificantControl[] Items { get; set; }

        [JsonProperty(PropertyName = "ceased_count")]
        public int? CeasedCount { get; set; }
    }
}
