using System.Collections.Generic;
using CompaniesHouse.Core.Response;

namespace CompaniesHouse.Core.Tests.MapProviders
{
    public class ResolutionCategoriesMapProvider : IEnumDataMapProvider<ResolutionCategory>
    {
        public IReadOnlyDictionary<string, ResolutionCategory> Map => EnumerationMappings.PossibleResolutionCategories;
    }
}
