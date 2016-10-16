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
    }
}
