using System.Collections.Generic;
using CompaniesHouse.Response.CompanyProfile;

namespace CompaniesHouse.Tests.MapProviders
{
    public class JurisdictionMapProvider : IEnumDataMapProvider<Jurisdiction>
    {
        public IReadOnlyDictionary<string, Jurisdiction> Map => EnumerationMappings.PossibleJurisdictions;
    }
}