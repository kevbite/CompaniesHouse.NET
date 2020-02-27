using System.Collections.Generic;
using CompaniesHouse.Core.Response.PersonsWithSignificantControl;

namespace CompaniesHouse.Core.Tests.MapProviders
{
    public class PersonWithSignificantControlKindMapProvider : IEnumDataMapProvider<PersonWithSignificantControlKind>
    {
        public IReadOnlyDictionary<string, PersonWithSignificantControlKind> Map => EnumerationMappings.PossiblePersonWithSignificantControlKinds;
    }
}
