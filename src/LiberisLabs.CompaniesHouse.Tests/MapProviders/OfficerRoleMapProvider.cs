using System.Collections.Generic;
using LiberisLabs.CompaniesHouse.Response.CompanyProfile;

namespace LiberisLabs.CompaniesHouse.Tests.MapProviders
{
    public class OfficerRoleMapProvider : IEnumDataMapProvider<OfficerRole>
    {
        public IReadOnlyDictionary<string, OfficerRole> Map => EnumerationMappings.PossibleOfficerRoles;
    }
}