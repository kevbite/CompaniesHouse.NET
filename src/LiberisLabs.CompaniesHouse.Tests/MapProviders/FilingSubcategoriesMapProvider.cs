using System.Collections.Generic;
using LiberisLabs.CompaniesHouse.Response;

namespace LiberisLabs.CompaniesHouse.Tests.MapProviders
{
    public class FilingSubcategoriesMapProvider : IEnumDataMapProvider<FilingSubcategory>
    {
        public IReadOnlyDictionary<string, FilingSubcategory> Map => EnumerationMappings.PossibleFilingSubcategories;
    }
}
