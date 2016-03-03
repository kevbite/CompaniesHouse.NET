using System.Runtime.Serialization;

namespace LiberisLabs.CompaniesHouse.Response
{
    public enum ResolutionCategory
    {
        None = 0,

        [EnumMember(Value = "miscellaneous")]
        Miscellaneous,
    }
}
