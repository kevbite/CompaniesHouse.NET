using System.Runtime.Serialization;

namespace LiberisLabs.CompaniesHouse.Response.CompanyFiling
{
    public enum FilingSubcategory
    {
        None = 0,

        [EnumMember(Value = "resolution")]
        Resloution,
    }
}
