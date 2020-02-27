using System.Collections.Generic;

namespace CompaniesHouse.Core.Tests.MapProviders
{
    public interface IEnumDataMapProvider<TEnum>
    {
        IReadOnlyDictionary<string, TEnum> Map { get; }
    }
}