using System.Collections.Generic;
using CompaniesHouse.Response;

namespace CompaniesHouse.Tests.MapProviders
{
    public class ClassificationChargeTypeMapProvider : IEnumDataMapProvider<ClassificationChargeType>
    {
        public IReadOnlyDictionary<string, ClassificationChargeType> Map => EnumerationMappings.PossibleClassificationChargeTypes;
    }
}