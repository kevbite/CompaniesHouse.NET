using System.Collections.Generic;
using CompaniesHouse.Core.Response.CompanyProfile;

namespace CompaniesHouse.Core.Tests.MapProviders
{
    public class JurisdictionMapProvider : IEnumDataMapProvider<Jurisdiction>
    {
        public IReadOnlyDictionary<string, Jurisdiction> Map => EnumerationMappings.PossibleJurisdictions;
    }
}