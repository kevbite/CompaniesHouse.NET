namespace CompaniesHouse.Response.Search.AllSearch
{
    public class Item
    {
        public Address address { get; set; } = null!;
        public string address_snippet { get; set; } = null!;
        public string description { get; set; } = null!;
        public string[] description_identifier { get; set; } = null!;
        public string kind { get; set; } = null!;
        public Links links { get; set; } = null!;
        public Matches matches { get; set; } = null!;
        public string snippet { get; set; } = null!;
        public string title { get; set; } = null!;
    }
}
