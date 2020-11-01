using System.Collections.Generic;
using CompaniesHouse.Response;

namespace CompaniesHouse.Tests.MapProviders
{
    public class ParticularTypeMapProvider : IEnumDataMapProvider<ParticularType>
    {
        public IReadOnlyDictionary<string, ParticularType> Map => EnumerationMappings.PossibleParticularTypes;
    }
}