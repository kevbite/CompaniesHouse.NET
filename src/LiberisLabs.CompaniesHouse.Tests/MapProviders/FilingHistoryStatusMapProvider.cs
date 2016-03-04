using System.Collections.Generic;
using LiberisLabs.CompaniesHouse.Response;

namespace LiberisLabs.CompaniesHouse.Tests.MapProviders
{
    public class FilingHistoryStatusMapProvider : IEnumDataMapProvider<FilingHistoryStatus>
    {
        public IReadOnlyDictionary<string, FilingHistoryStatus> Map => EnumerationMappings.PossibleFilingHistoryStatus;
    }
}
