using System.Collections.Generic;
using CompaniesHouse.Response;

namespace CompaniesHouse.Tests.MapProviders
{
    public class CompanyStatusMapProvider : IEnumDataMapProvider<CompanyStatus>
    {
        public IReadOnlyDictionary<string, CompanyStatus> Map => EnumerationMappings.PossibleCompanyStatuses;
    }
}