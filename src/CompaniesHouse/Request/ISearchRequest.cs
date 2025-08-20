namespace CompaniesHouse.Request;

public interface ISearchRequest
{
    int? ItemsPerPage { get; }

    int? StartIndex { get; }
}