using System.Runtime.Serialization;

namespace CompaniesHouse.Response.PersonsWithSignificantControl
{
    public enum PersonWithSignificantControlKind
    {
        [EnumMember(Value = "corporate-entity-person-with-significant-control")]
        CorporateEntityPersonWithSignificantControl,

        [EnumMember(Value = "individual-person-with-significant-control")]
        IndividualPersonWithSignificantControl,

        [EnumMember(Value = "super-secure-person-with-significant-control")]
        SuperSecurePersonWithSignificantControl,

        [EnumMember(Value = "legal-person-person-with-significant-control")]
        LegalPersonPersonWithSignificantControl,
    }
}
