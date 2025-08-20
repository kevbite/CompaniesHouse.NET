namespace CompaniesHouse.Request;

public interface IQuerySearchRequest : ISearchRequest
{
    string Query { get; }
}