using System.Collections.Generic;
using CompaniesHouse.Core.Response.Officers;

namespace CompaniesHouse.Core.Tests.MapProviders
{
    public class OfficerRoleMapProvider : IEnumDataMapProvider<OfficerRole>
    {
        public IReadOnlyDictionary<string, OfficerRole> Map => EnumerationMappings.PossibleOfficerRoles;
    }
}