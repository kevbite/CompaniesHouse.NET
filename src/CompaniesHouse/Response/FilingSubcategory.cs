using System.Runtime.Serialization;

namespace CompaniesHouse.Response
{
    public enum FilingSubcategory
    {
        None = 0,

        [EnumMember(Value = "annual-return")]
        AnnualReturn,

        [EnumMember(Value = "resolution")]
        Resolution,

        [EnumMember(Value = "change")]
        Change,

        [EnumMember(Value = "create")]
        Create,

        [EnumMember(Value = "certificate")]
        Certificate,

        [EnumMember(Value = "appointments")]
        Appointments,

        [EnumMember(Value = "satisfy")]
        Satisfy,

        [EnumMember(Value = "termination")]
        Termination,

        [EnumMember(Value = "release-cease")]
        ReleaseCease,

        [EnumMember(Value = "voluntary")]
        Voluntary,

        [EnumMember(Value = "administration")]
        Administration,

        [EnumMember(Value = "compulsory")]
        Compulsory,

        [EnumMember(Value = "court-order")]
        CourtOrder,

        [EnumMember(Value = "other")]
        Other,

        [EnumMember(Value = "notifications")]
        Notifications,

        [EnumMember(Value = "officers")]
        Officers,

        [EnumMember(Value = "document-replacement")]
        DocumentReplacement,

        [EnumMember(Value = "statements")]
        Statements,

        [EnumMember(Value = "voluntary-arrangement")]
        VoluntaryArrangement,

        [EnumMember(Value = "alter")]
        Alter,
        
        [EnumMember(Value = "register")]
        Register,

        [EnumMember(Value = "receiver")]
        Receiver,

        [EnumMember(Value = "voluntary-arrangement-moratoria")]
        VoluntaryArrangementMoratoria,

        [EnumMember(Value = "acquire")]
        Acquire,

        [EnumMember(Value = "trustee")]
        Trustee,

        [EnumMember(Value = "mortgage")]
        Mortgage,

        [EnumMember(Value = "transfer")]
        Transfer,
        
        [EnumMember(Value = "debenture")]
        Debenture,

        [EnumMember(Value = "social-landlord")]
        SocialLandlord,
    }
}
