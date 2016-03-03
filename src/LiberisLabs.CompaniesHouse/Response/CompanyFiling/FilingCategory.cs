using System.Runtime.Serialization;

namespace LiberisLabs.CompaniesHouse.Response.CompanyFiling
{
    public enum FilingCategory
    {
        None = 0,

        [EnumMember(Value = "accounts")]
        Accounts,

        [EnumMember(Value = "address")]
        Address,

        [EnumMember(Value = "annual-return")]
        AnnualReturn,

        [EnumMember(Value = "capital")]
        Capital,

        [EnumMember(Value = "change-of-name")]
        ChangeOfName,

        [EnumMember(Value = "incorporation")]
        Incorporation,

        [EnumMember(Value = "liquidation")]
        Liquidation,

        [EnumMember(Value = "miscellaneous")]
        Miscellaneous,

        [EnumMember(Value = "mortgage")]
        Mortgage,

        [EnumMember(Value = "officers")]
        Officers,

        [EnumMember(Value = "resolution")]
        Resolution
    }
}
