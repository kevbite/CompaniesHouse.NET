using System.Runtime.Serialization;

namespace LiberisLabs.CompaniesHouse.Response
{
    public enum CompanyType
    {
        None = 0,

        [EnumMember(Value = "private-unlimited")]
        PrivateUnlimited,

        [EnumMember(Value = "ltd")]
        Ltd,

        [EnumMember(Value = "plc")]
        Plc,

        [EnumMember(Value = "old-public-company")]
        OldPublicCompany,

        [EnumMember(Value = "private-limited-guarant-nsc-limited-exemption")]
        PrivateLimitedGuarantNscLimitedExemption,

        [EnumMember(Value = "limited-partnership")]
        LimitedPartnership,

        [EnumMember(Value = "private-limited-guarant-nsc")]
        PrivateLimitedGuarantNsc,

        [EnumMember(Value = "converted-or-closed")]
        ConvertedOrClosed,

        [EnumMember(Value = "private-unlimited-nsc")]
        PrivateUnlimitedNsc,
        
        [EnumMember(Value = "private-limited-shares-section-30-exemption")]
        PrivateLimitedSharesSection30Exemption,

        [EnumMember(Value = "assurance-company")]
        AssuranceCompany,

        [EnumMember(Value = "oversea-company")]
        OverseaCompany,

        [EnumMember(Value = "eeig")]
        Eeig,

        [EnumMember(Value = "icvc-securities")]
        IcvcSecurities,

        [EnumMember(Value = "icvc-warrant")]
        IcvcWarrant,

        [EnumMember(Value = "icvc-umbrella")]
        IcvcUmbrella,

        [EnumMember(Value = "industrial-and-provident-society")]
        IndustrialAndProvidentSociety,

        [EnumMember(Value = "northern-ireland")]
        NorthernIreland,

        [EnumMember(Value = "northern-ireland-other")]
        NorthernIrelandOther,

        [EnumMember(Value = "llp")]
        Llp,

        [EnumMember(Value = "royal-charter")]
        RoyalCharter,

        [EnumMember(Value = "investment-company-with-variable-capital")]
        InvestmentCompanyWithVariableCapital,

        [EnumMember(Value = "unregistered-company")]
        UnregisteredCompany,

        [EnumMember(Value = "other")]
        Other,

        [EnumMember(Value = "european-public-limited-liability-company-se")]
        EuropeanPublicLimitedLiabilityCompanySe,
    }
}