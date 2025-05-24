using System.Runtime.Serialization;

namespace CompaniesHouse.Response.CompanyProfile;

public enum ForeignAccountType
{ 
    [EnumMember(Value = "")]
    None = 0,
        
    [EnumMember(Value = "accounting-requirements-of-originating-country-apply")]
    AccountingRequirementsOfOriginatingCountryApply,
        
    [EnumMember(Value = "accounting-requirements-of-originating-country-do-not-apply")]
    AccountingRequirementsOfOriginatingCountryDoNotApply
}