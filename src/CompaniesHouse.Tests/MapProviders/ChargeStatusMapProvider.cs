using System.Collections.Generic;
using CompaniesHouse.Response;

namespace CompaniesHouse.Tests.MapProviders
{
    public class ChargeStatusMapProvider : IEnumDataMapProvider<ChargeStatus>
    {
        public IReadOnlyDictionary<string, ChargeStatus> Map => EnumerationMappings.PossibleChargeStatuses;
    }
}