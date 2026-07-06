using CompaniesHouse.Response.Search.CompaniesAlphabeticallySearch;

namespace CompaniesHouse.Request;

public class SearchCompaniesAlphabeticallyRequest
{
    public string Query { get; set; } = "";

    public string? SearchAbove { get; set; }

    public string? SearchBelow { get; set; }

    public int? Size { get; set; }
}
