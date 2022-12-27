using System.Collections.Generic;
using CompaniesHouse.Response;

namespace CompaniesHouse.Tests.MapProviders
{
    public class AssetsCeasedReleasedMapProvider : IEnumDataMapProvider<AssetsCeasedReleased>
    {
        public IReadOnlyDictionary<string, AssetsCeasedReleased> Map => EnumerationMappings.PossibleAssetsCeasedReleased;
    }
}