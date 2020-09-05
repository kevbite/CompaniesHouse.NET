using System.Runtime.Serialization;

namespace CompaniesHouse.Response
{
    public enum FilingHistoryStatus
    {
        None = 0,

        [EnumMember(Value = "filing-history-available")]
        FilingHistoryAvailable,

        [EnumMember(Value = "filing-history-not-available-invalid-format")]
        InvalidFormat,
        
        [EnumMember(Value = "filing-history-available-no-images-limited-partnership-from-1988")]
        FilingHistoryAvailableNoImagesLimitedPartnershipFrom1988,

        [EnumMember(Value = "filing-history-available-assurance-company-before-2004")]
        FilingHistoryAvailableAssuranceCompanyBefore2004,

        [EnumMember(Value = "filing-history-available-limited-partnership-from-2014")]
        FilingHistoryAvailableLimitedPartnershipFrom2014,

        [EnumMember(Value = "filing-history-not-available-industrial-and-provident-society")]
        FilingHistoryNotAvailableIndustrialAndProvidentSociety,

        [EnumMember(Value = "filing-history-not-available-limited-partnership-before-1988")]
        FilingHistoryNotAvailableLimitedPartnershipBefore1988,

        [EnumMember(Value = "filing-history-not-available-royal-charter")]
        FilingHistoryNotAvailableRoyalCharter,

        [EnumMember(Value = "filing-history-not-available-scottish-industrial-and-provident-society")]
        FilingHistoryNotAvailableScottishIndustrialAndProvidentSociety,

        [EnumMember(Value = "filing-history-not-available-northern-ireland-industrial-and-provident-society")]
        FilingHistoryNotAvailableNorthernIrelandIndustrialAndProvidentSociety,
    }
}
