using System.Runtime.Serialization;

namespace LiberisLabs.CompaniesHouse.Response.CompanyFiling
{
    public enum HistoryStatus
    {
        None = 0,

        [EnumMember(Value = "filing-history-available")]
        FilingHistoryAvailable,
    }
}
