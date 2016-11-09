namespace CompaniesHouse.Response.Search.AllSearch
{
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
}