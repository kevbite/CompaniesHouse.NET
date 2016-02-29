using System.Collections.Generic;
using LiberisLabs.CompaniesHouse.Response;

namespace LiberisLabs.CompaniesHouse.Tests.MapProviders
{
    public class CompanyStatusMapProvider : IEnumDataMapProvider<CompanyStatus>
    {
        public IReadOnlyDictionary<string, CompanyStatus> Map => EnumerationMappings.PossibleCompanyStatuses;
    }
}