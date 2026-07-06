namespace CompaniesHouse.Request;

public interface ISearchRequest
{
    string Query { get; }

    int? ItemsPerPage { get; }

    int? StartIndex { get; }
}