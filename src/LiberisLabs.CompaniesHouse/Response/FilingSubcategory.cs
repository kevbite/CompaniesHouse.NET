using System.Runtime.Serialization;

namespace LiberisLabs.CompaniesHouse.Response
{
    public enum FilingSubcategory
    {
        None = 0,

        [EnumMember(Value = "resolution")]
        Resolution,

        [EnumMember(Value = "change")]
        Change,

        [EnumMember(Value = "appointments")]
        Appointments,

        [EnumMember(Value = "termination")]
        Termination,
    }
}
