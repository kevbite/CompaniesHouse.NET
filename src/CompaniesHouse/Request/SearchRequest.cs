namespace CompaniesHouse.Request
{
    public abstract class SearchRequest<TReturn> : ISearchRequest
    {
        public string Query { get; set; } = "";

        public int? ItemsPerPage { get; set; }

        public int? StartIndex { get; set; }
    }
}