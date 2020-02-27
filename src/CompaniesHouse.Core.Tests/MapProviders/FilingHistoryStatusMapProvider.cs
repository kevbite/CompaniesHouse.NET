using System.Collections.Generic;
using CompaniesHouse.Core.Response;

namespace CompaniesHouse.Core.Tests.MapProviders
{
    public class FilingHistoryStatusMapProvider : IEnumDataMapProvider<FilingHistoryStatus>
    {
        public IReadOnlyDictionary<string, FilingHistoryStatus> Map => EnumerationMappings.PossibleFilingHistoryStatus;
    }
}
