using System.Collections.Generic;
using CompaniesHouse.Core.Response;

namespace CompaniesHouse.Core.Tests.MapProviders
{
    public class FilingSubcategoriesMapProvider : IEnumDataMapProvider<FilingSubcategory>
    {
        public IReadOnlyDictionary<string, FilingSubcategory> Map => EnumerationMappings.PossibleFilingSubcategories;
    }
}
