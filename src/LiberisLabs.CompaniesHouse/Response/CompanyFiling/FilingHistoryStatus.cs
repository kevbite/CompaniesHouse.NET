using System.Runtime.Serialization;

namespace LiberisLabs.CompaniesHouse.Response.CompanyFiling
{
    public enum FilingHistoryStatus
    {
        None = 0,

        [EnumMember(Value = "filing-history-available")]
        FilingHistoryAvailable,
    }
}
