using System;
using System.Collections.Generic;
using CompaniesHouse.Response;
using CompaniesHouse.Response.Search.AdvancedCompanySearch;

namespace CompaniesHouse.Request;

public class AdvancedCompanySearchRequest
{
    public string? CompanyNameIncludes { get; set; }

    public string? CompanyNameExcludes { get; set; }

    public IReadOnlyCollection<CompanyStatus>? CompanyStatuses { get; set; }

    public IReadOnlyCollection<CompanySubtype>? CompanySubtypes { get; set; }

    public IReadOnlyCollection<CompanyType>? CompanyTypes { get; set; }

    public DateTime? DissolvedFrom { get; set; }

    public DateTime? DissolvedTo { get; set; }

    public DateTime? IncorporatedFrom { get; set; }

    public DateTime? IncorporatedTo { get; set; }

    public string? Location { get; set; }

    public IReadOnlyCollection<string>? SicCodes { get; set; }

    public int? Size { get; set; }

    public int? StartIndex { get; set; }
}
