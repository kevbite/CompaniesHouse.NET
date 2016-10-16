using System.Collections.Generic;

namespace CompaniesHouse.Tests.MapProviders
{
    public interface IEnumDataMapProvider<TEnum>
    {
        IReadOnlyDictionary<string, TEnum> Map { get; }
    }
}