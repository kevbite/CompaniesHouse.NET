using System.Collections.Generic;
using CompaniesHouse.Response;

namespace CompaniesHouse.Tests.MapProviders
{
    public class FilingCategoriesMapProvider : IEnumDataMapProvider<FilingCategory>
    {
        public IReadOnlyDictionary<string, FilingCategory> Map => EnumerationMappings.PossibleFilingCategories;
    }
}
