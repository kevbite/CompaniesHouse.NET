using System.Collections.Generic;
using LiberisLabs.CompaniesHouse.Response;

namespace LiberisLabs.CompaniesHouse.Tests.MapProviders
{
    public class CompanyStatusDetailMapProvider : IEnumDataMapProvider<CompanyStatusDetail>
    {
        public IReadOnlyDictionary<string, CompanyStatusDetail> Map => EnumerationMappings.PossibleCompanyStatusDetails;
    }
}