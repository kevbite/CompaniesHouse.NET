using System.Collections.Generic;

namespace LiberisLabs.CompaniesHouse.Tests.MapProviders
{
    public interface IEnumDataMapProvider<TEnum>
    {
        IReadOnlyDictionary<string, TEnum> Map { get; }
    }
}