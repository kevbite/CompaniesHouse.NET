using System.Runtime.Serialization;

namespace LiberisLabs.CompaniesHouse.Response.CompanySearch
{
    public enum CompanyStatus
    {
        None = 0,

        [EnumMember(Value = "active")]
        Active,

        [EnumMember(Value = "dissolved")]
        Dissolved,

        [EnumMember(Value = "liquidation")]
        Liquidation,

        [EnumMember(Value = "receivership")]
        Receivership,

        [EnumMember(Value = "administration")]
        Administration,

        [EnumMember(Value = "voluntary-arrangement")]
        VoluntaryArrangement,

        [EnumMember(Value = "converted-closed")]
        ConvertedClosed,

        [EnumMember(Value = "insolvency-proceedings")]
        InsolvencyProceedings

    }
}