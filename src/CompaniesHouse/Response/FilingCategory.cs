using System.Runtime.Serialization;

namespace CompaniesHouse.Response
{
    public enum FilingCategory
    {
        None = 0,

        [EnumMember(Value = "auditors")]
        Auditors,

        [EnumMember(Value = "accounts")]
        Accounts,

        [EnumMember(Value = "address")]
        Address,

        [EnumMember(Value = "annual-return")]
        AnnualReturn,

        [EnumMember(Value = "capital")]
        Capital,

        [EnumMember(Value = "gazette")]
        Gazette,

        [EnumMember(Value = "change-of-name")]
        ChangeOfName,

        [EnumMember(Value = "incorporation")]
        Incorporation,

        [EnumMember(Value = "liquidation")]
        Liquidation,

        [EnumMember(Value = "miscellaneous")]
        Miscellaneous,

        [EnumMember(Value = "mortgage")]
        Mortgage,

        [EnumMember(Value = "officers")]
        Officers,

        [EnumMember(Value = "resolution")]
        Resolution,
        
        [EnumMember(Value = "restoration")]
        Restoration,
        
        [EnumMember(Value = "change-of-constitution")]
        ChangeOfConstitution,

        [EnumMember(Value = "document-replacement")]
        DocumentReplacement,

        [EnumMember(Value = "insolvency")]
        Insolvency,

        [EnumMember(Value = "confirmation-statement")]
        ConfirmationStatement,

        [EnumMember(Value = "persons-with-significant-control")]
        PersonsWithSignificantControl,

        [EnumMember(Value = "historical")]
        Historical,

        [EnumMember(Value = "dissolution")]
        Dissolution,
    }
}
