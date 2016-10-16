using System.Runtime.Serialization;

namespace CompaniesHouse.Response
{
    public enum ResolutionCategory
    {
        None = 0,

        [EnumMember(Value = "capital")]
        Capital,

        [EnumMember(Value = "incorporation")]
        Incorporation,

        [EnumMember(Value = "miscellaneous")]
        Miscellaneous,

        [EnumMember(Value = "resolution")]
        Resolution,

        [EnumMember(Value = "change-of-name")]
        ChangeOfName
    }
}
