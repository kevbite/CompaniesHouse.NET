using System.Runtime.Serialization;

namespace CompaniesHouse.Core.Response.CompanyProfile
{
    public enum Jurisdiction
    {
        None = 0,

        [EnumMember(Value = "england-wales")]
        EnglandAndWales,

        [EnumMember(Value = "wales")]
        Wales,

        [EnumMember(Value = "scotland")]
        Scotland,

        [EnumMember(Value = "northern-ireland")]
        NorthernIreland,

        [EnumMember(Value = "european-union")]
        EuropeanUnion,

        [EnumMember(Value = "united-kingdom")]
        UnitedKingdom,

        [EnumMember(Value = "england")]
        England,

        [EnumMember(Value = "noneu")]
        NonEu
    }
}