using System.Collections.Generic;
using LiberisLabs.CompaniesHouse.Response;

namespace LiberisLabs.CompaniesHouse.Tests.MapProviders
{
    public class CompanyTypesMapProvider : IEnumDataMapProvider<CompanyType>
    {
        public IReadOnlyDictionary<string, CompanyType> Map => EnumerationMappings.ExpectedCompanyTypesMap;
    }
}