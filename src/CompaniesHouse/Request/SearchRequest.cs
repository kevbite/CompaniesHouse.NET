namespace CompaniesHouse.Request
{
    public abstract class QuerySearchRequest<TReturn> : SearchRequest<TReturn>, IQuerySearchRequest
    {
        public string Query { get; set; } = "";
    }

    public abstract class SearchRequest<TReturn> : ISearchRequest
    {
        public int? ItemsPerPage { get; set; }

        public int? StartIndex { get; set; }
    }
}