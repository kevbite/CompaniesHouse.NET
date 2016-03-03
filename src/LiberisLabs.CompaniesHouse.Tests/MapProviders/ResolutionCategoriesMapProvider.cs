using System.Collections.Generic;
using LiberisLabs.CompaniesHouse.Response;

namespace LiberisLabs.CompaniesHouse.Tests.MapProviders
{
    public class ResolutionCategoriesMapProvider : IEnumDataMapProvider<ResolutionCategory>
    {
        public IReadOnlyDictionary<string, ResolutionCategory> Map => EnumerationMappings.PossibleResolutionCategories;
    }
}
