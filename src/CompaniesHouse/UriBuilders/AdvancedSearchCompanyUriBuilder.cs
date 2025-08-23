using System.Text;
using CompaniesHouse.Request;

namespace CompaniesHouse.UriBuilders;

public class AdvancedSearchCompanyUriBuilder : SearchUriBuilder<AdvancedSearchCompanyRequest>
{
    public AdvancedSearchCompanyUriBuilder(string path) : base(path)
    {
    }

    protected override string BuildQuery(AdvancedSearchCompanyRequest request)
    {
        var queryBuilder = new StringBuilder(base.BuildQuery(request));

        AppendParameterIfValid(queryBuilder, "company_name_includes", request.CompanyNameIncludes, value => !string.IsNullOrWhiteSpace(value));
        AppendParameterIfValid(queryBuilder, "company_name_excludes", request.CompanyNameExcludes, value => !string.IsNullOrWhiteSpace(value));
        AppendParameterIfValid(queryBuilder, "company_status", request.CompanyStatus);
        AppendParameterIfValid(queryBuilder, "company_subtype", request.CompanySubtype);
        AppendParameterIfValid(queryBuilder, "company_type", request.CompanyType);
        AppendParameterIfValid(queryBuilder, "dissolved_from", request.DissolvedFrom, value => value.HasValue);
        AppendParameterIfValid(queryBuilder, "dissolved_to", request.DissolvedTo, value =>value.HasValue);
        AppendParameterIfValid(queryBuilder, "incorporated_from", request.IncorporatedFrom, value =>value.HasValue);
        AppendParameterIfValid(queryBuilder, "incorporated_to", request.IncorporatedTo, value => value.HasValue);
        AppendParameterIfValid(queryBuilder, "location", request.Location, value => !string.IsNullOrWhiteSpace(value));
        AppendParameterIfValid(queryBuilder, "sic_codes", request.SicCodes);
     
        return queryBuilder.ToString();
    }
}