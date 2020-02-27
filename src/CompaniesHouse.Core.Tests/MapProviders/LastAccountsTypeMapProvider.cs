using System.Collections.Generic;
using CompaniesHouse.Core.Response.CompanyProfile;
using CompaniesHouse.Core.Response;

namespace CompaniesHouse.Core.Tests.MapProviders
{
    public class LastAccountsTypeMapProvider : IEnumDataMapProvider<LastAccountsType>
    {
        public IReadOnlyDictionary<string, LastAccountsType> Map => EnumerationMappings.PossibleLastAccountsTypes;
    }
}