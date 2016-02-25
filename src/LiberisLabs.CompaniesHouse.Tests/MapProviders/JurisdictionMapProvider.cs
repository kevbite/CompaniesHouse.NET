using System.Collections.Generic;
using LiberisLabs.CompaniesHouse.Response.CompanyProfile;

namespace LiberisLabs.CompaniesHouse.Tests.MapProviders
{
    public class JurisdictionMapProvider : IEnumDataMapProvider<Jurisdiction>
    {
        public IReadOnlyDictionary<string, Jurisdiction> Map => EnumerationMappings.PossibleJurisdictions;
    }
}