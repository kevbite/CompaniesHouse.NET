using System.Collections.Generic;
using CompaniesHouse.Response.PersonsWithSignificantControl;

namespace CompaniesHouse.Tests.MapProviders
{
    public class PersonWithSignificantControlKindMapProvider : IEnumDataMapProvider<PersonWithSignificantControlKind>
    {
        public IReadOnlyDictionary<string, PersonWithSignificantControlKind> Map => EnumerationMappings.PossiblePersonWithSignificantControlKinds;
    }
}
