using System.Collections.Generic;
using CompaniesHouse.Response;

namespace CompaniesHouse.Tests.MapProviders
{
    public class CompanyStatusDetailMapProvider : IEnumDataMapProvider<CompanyStatusDetail>
    {
        public IReadOnlyDictionary<string, CompanyStatusDetail> Map => EnumerationMappings.PossibleCompanyStatusDetails;
    }
}