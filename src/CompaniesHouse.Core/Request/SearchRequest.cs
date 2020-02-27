namespace CompaniesHouse.Core.Request
{
    public class SearchRequest
    {
        public string Query { get; set; }

        public int? ItemsPerPage { get; set; }

        public int? StartIndex { get; set; }
    }
}
