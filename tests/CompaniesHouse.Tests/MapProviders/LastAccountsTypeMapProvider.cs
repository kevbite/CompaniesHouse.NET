using System.Collections.Generic;
using CompaniesHouse.Response.CompanyProfile;
using CompaniesHouse.Response;

namespace CompaniesHouse.Tests.MapProviders
{
    public class LastAccountsTypeMapProvider : IEnumDataMapProvider<LastAccountsType>
    {
        public IReadOnlyDictionary<string, LastAccountsType> Map => EnumerationMappings.PossibleLastAccountsTypes;
    }
}