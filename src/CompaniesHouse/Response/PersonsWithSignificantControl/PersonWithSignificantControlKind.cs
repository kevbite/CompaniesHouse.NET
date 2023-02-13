using System.Runtime.Serialization;

namespace CompaniesHouse.Response.PersonsWithSignificantControl
{
    public enum PersonWithSignificantControlKind
    {
        [EnumMember(Value = "corporate-entity-person-with-significant-control")]
        CorporateEntityPersonWithSignificantControl,

        [EnumMember(Value = "corporate-entity-beneficial-owner")]
        CorporateEntityBeneficialOwner,
        
        [EnumMember(Value = "individual-person-with-significant-control")]
        IndividualPersonWithSignificantControl,

        [EnumMember(Value = "individual-beneficial-owner")]
        IndividualBeneficialOwner,
        
        [EnumMember(Value = "super-secure-person-with-significant-control")]
        SuperSecurePersonWithSignificantControl,

        [EnumMember(Value = "super-secure-beneficial-owner")]
        SuperSecureBeneficialOwner,
        
        [EnumMember(Value = "legal-person-person-with-significant-control")]
        LegalPersonPersonWithSignificantControl,
        
        [EnumMember(Value = "legal-person-beneficial-owner")]
        LegalPersonBeneficialOwner,
    }
}