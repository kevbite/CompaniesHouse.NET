using System.Runtime.Serialization;

namespace LiberisLabs.CompaniesHouse.Response
{
    public enum FilingHistoryStatus
    {
        None = 0,

        [EnumMember(Value = "filing-history-available")]
        FilingHistoryAvailable,
    }
}
