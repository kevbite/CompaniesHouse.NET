using System.Collections.Generic;
using CompaniesHouse.Response;

namespace CompaniesHouse.Tests.MapProviders
{
    public class CompanyTypesMapProvider : IEnumDataMapProvider<CompanyType>
    {
        public IReadOnlyDictionary<string, CompanyType> Map => EnumerationMappings.ExpectedCompanyTypesMap;
    }
}