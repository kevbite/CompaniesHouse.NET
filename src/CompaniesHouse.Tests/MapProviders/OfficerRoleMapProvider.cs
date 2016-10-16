using System.Collections.Generic;
using CompaniesHouse.Response.CompanyProfile;

namespace CompaniesHouse.Tests.MapProviders
{
    public class OfficerRoleMapProvider : IEnumDataMapProvider<OfficerRole>
    {
        public IReadOnlyDictionary<string, OfficerRole> Map => EnumerationMappings.PossibleOfficerRoles;
    }
}