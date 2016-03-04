using System.Collections.Generic;
using LiberisLabs.CompaniesHouse.Response;

namespace LiberisLabs.CompaniesHouse.Tests.MapProviders
{
    public class FilingCategoriesMapProvider : IEnumDataMapProvider<FilingCategory>
    {
        public IReadOnlyDictionary<string, FilingCategory> Map => EnumerationMappings.PossibleFilingCategories;
    }
}
