using System.Collections.Generic;
using CompaniesHouse.Core.Response;

namespace CompaniesHouse.Core.Tests.MapProviders
{
    public class CompanyStatusDetailMapProvider : IEnumDataMapProvider<CompanyStatusDetail>
    {
        public IReadOnlyDictionary<string, CompanyStatusDetail> Map => EnumerationMappings.PossibleCompanyStatusDetails;
    }
}