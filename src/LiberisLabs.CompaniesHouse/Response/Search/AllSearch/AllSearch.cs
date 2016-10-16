using LiberisLabs.CompaniesHouse.JsonConverters;
using Newtonsoft.Json;

namespace LiberisLabs.CompaniesHouse.Response.Search.AllSearch
{
    public class AllSearch
    {
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; set; }

        [JsonProperty(PropertyName = "items")]
        public SearchItem[] Items { get; set; }

        [JsonProperty(PropertyName = "items_per_page")]
        public string ItemsPerPage { get; set; }

        [JsonProperty(PropertyName = "kind")]
        public string Kind { get; set; }

        [JsonProperty(PropertyName = "start_index")]
        public string StartIndex { get; set; }

        [JsonProperty(PropertyName = "total_results")]
        public string TotalResults { get; set; }
    }

    public class Item
    {
        public Address address { get; set; }
        public string address_snippet { get; set; }
        public string description { get; set; }
        public string[] description_identifier { get; set; }
        public string kind { get; set; }
        public Links links { get; set; }
        public Matches matches { get; set; }
        public string snippet { get; set; }
        public string title { get; set; }
    }

    public class Address
    {
        [JsonProperty(PropertyName = "address_line_1")]
        public string AddressLine1 { get; set; }

        [JsonProperty(PropertyName = "address_line_2")]
        public string AddressLine2 { get; set; }

        [JsonProperty(PropertyName = "care_of")]
        public string CareOf { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "locality")]
        public string Locality { get; set; }

        [JsonProperty(PropertyName = "po_box")]
        public string PoBox { get; set; }

        [JsonProperty(PropertyName = "postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }
    }

    public class Links
    {
        [JsonProperty(PropertyName = "self")]
        public string Self { get; set; }
    }

    public class Matches
    {
        [JsonProperty(PropertyName = "address_snippet")]
        public string[] AddressSnippet { get; set; }
        [JsonProperty(PropertyName = "snippet")]
        public string[] Snippet { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string[] Title { get; set; }
    }

}
