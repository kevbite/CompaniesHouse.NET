using System.Runtime.Serialization;

namespace CompaniesHouse.Response;

public enum CompanySubType
{
    [EnumMember(Value = "")] None = 0,

    [EnumMember(Value = "community-interest-company")]
    CommunityInterestCompany,
        
    [EnumMember(Value = "private-fund-limited-partnership")]
    PrivateFundLimitedPartnership,
}