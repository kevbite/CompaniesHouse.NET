using System.Collections.Generic;
using CompaniesHouse.Response;

namespace CompaniesHouse.Tests.MapProviders
{
    public class SecureDetailTypeMapProvider : IEnumDataMapProvider<SecuredDetailType>
    {
        public IReadOnlyDictionary<string, SecuredDetailType> Map => EnumerationMappings.PossibleSecuredDetailTypes;
    }
}