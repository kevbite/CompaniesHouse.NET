using System.Collections.Generic;
using CompaniesHouse.Response;

namespace CompaniesHouse.Tests.MapProviders
{
    public class FilingHistoryStatusMapProvider : IEnumDataMapProvider<FilingHistoryStatus>
    {
        public IReadOnlyDictionary<string, FilingHistoryStatus> Map => EnumerationMappings.PossibleFilingHistoryStatus;
    }
}
