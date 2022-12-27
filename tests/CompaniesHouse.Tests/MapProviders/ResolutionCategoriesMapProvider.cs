using System.Collections.Generic;
using CompaniesHouse.Response;

namespace CompaniesHouse.Tests.MapProviders
{
    public class ResolutionCategoriesMapProvider : IEnumDataMapProvider<ResolutionCategory>
    {
        public IReadOnlyDictionary<string, ResolutionCategory> Map => EnumerationMappings.PossibleResolutionCategories;
    }
}
