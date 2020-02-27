using System.Collections.Generic;
using CompaniesHouse.Core.Response;

namespace CompaniesHouse.Core.Tests.MapProviders
{
    public class CompanyStatusMapProvider : IEnumDataMapProvider<CompanyStatus>
    {
        public IReadOnlyDictionary<string, CompanyStatus> Map => EnumerationMappings.PossibleCompanyStatuses;
    }
}