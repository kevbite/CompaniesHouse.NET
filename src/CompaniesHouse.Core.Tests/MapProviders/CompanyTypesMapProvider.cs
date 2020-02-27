using System.Collections.Generic;
using CompaniesHouse.Core.Response;

namespace CompaniesHouse.Core.Tests.MapProviders
{
    public class CompanyTypesMapProvider : IEnumDataMapProvider<CompanyType>
    {
        public IReadOnlyDictionary<string, CompanyType> Map => EnumerationMappings.ExpectedCompanyTypesMap;
    }
}