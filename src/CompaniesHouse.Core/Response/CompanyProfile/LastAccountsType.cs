using System.Runtime.Serialization;

namespace CompaniesHouse.Response.CompanyProfile
{
    public enum LastAccountsType
    {
        None = 0,

        [EnumMember(Value = "null")]
        Null,

        [EnumMember(Value = "full")]
        Full,

        [EnumMember(Value = "small")]
        Small,

        [EnumMember(Value = "medium")]
        Medium,

        [EnumMember(Value = "group")]
        Group,

        [EnumMember(Value = "dormant")]
        Dormant,

        [EnumMember(Value = "interim")]
        Interim,

        [EnumMember(Value = "initial")]
        Initial,

        [EnumMember(Value = "total-exemption-full")]
        TotalExemptionFull,
        
        [EnumMember(Value = "total-exemption-small")]
        TotalExemptionSmall,

        [EnumMember(Value = "partial-exemption")]
        PartialExemption,

        [EnumMember(Value = "audit-exemption-subsidiary")]
        AuditExemptionSubsidiary,

        [EnumMember(Value = "filing-exemption-subsidiary")]
        FilingExemptionSubsidiary,

        [EnumMember(Value = "micro-entity")]
        MicroEntity
    }
}