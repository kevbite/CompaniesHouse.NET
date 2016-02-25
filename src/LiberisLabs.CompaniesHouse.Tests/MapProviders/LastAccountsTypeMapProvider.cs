using System.Collections.Generic;
using LiberisLabs.CompaniesHouse.Response;
using LiberisLabs.CompaniesHouse.Response.CompanyProfile;

namespace LiberisLabs.CompaniesHouse.Tests.MapProviders
{
    public class LastAccountsTypeMapProvider : IEnumDataMapProvider<LastAccountsType>
    {
        public IReadOnlyDictionary<string, LastAccountsType> Map => EnumerationMappings.PossibleLastAccountsTypes;
    }
}