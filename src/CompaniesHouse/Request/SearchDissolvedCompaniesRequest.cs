using CompaniesHouse.Response.Search.DissolvedCompaniesSearch;

namespace CompaniesHouse.Request;

public class SearchDissolvedCompaniesRequest
{
    public string Query { get; set; } = "";

    public string SearchType { get; set; } = "";

    public string? SearchAbove { get; set; }

    public string? SearchBelow { get; set; }

    public int? Size { get; set; }

    public int? StartIndex { get; set; }
}
