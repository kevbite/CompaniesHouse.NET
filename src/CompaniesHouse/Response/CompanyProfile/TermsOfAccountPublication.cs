using System.Runtime.Serialization;

namespace CompaniesHouse.Response.CompanyProfile;

public enum TermsOfAccountPublication
{
    [EnumMember(Value = "")]
    None = 0,
    [EnumMember(Value = "accounts-publication-date-supplied-by-company")]
    AccountsPublicationDateSuppliedByCompany,
    [EnumMember(Value = "accounting-publication-date-does-not-need-to-be-supplied-by-company")]
    AccountingPublicationDateDoesNotNeedToBeSuppliedByCompany,
    [EnumMember(Value = "accounting-reference-date-allocated-by-companies-house")]
    AccountingReferenceDateAllocatedByCompaniesHouse
}