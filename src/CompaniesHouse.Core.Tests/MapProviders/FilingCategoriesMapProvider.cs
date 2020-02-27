using System.Collections.Generic;
using CompaniesHouse.Core.Response;

namespace CompaniesHouse.Core.Tests.MapProviders
{
    public class FilingCategoriesMapProvider : IEnumDataMapProvider<FilingCategory>
    {
        public IReadOnlyDictionary<string, FilingCategory> Map => EnumerationMappings.PossibleFilingCategories;
    }
}
