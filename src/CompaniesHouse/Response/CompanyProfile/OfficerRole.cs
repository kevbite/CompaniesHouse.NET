using System.Runtime.Serialization;

namespace CompaniesHouse.Response.CompanyProfile
{
    public enum OfficerRole
    {
        None = 0,

        [EnumMember(Value = "cic-manager")]
        CicManager,

        [EnumMember(Value = "corporate-director")]
        CorporateDirector,

        [EnumMember(Value = "corporate-llp-designated-member")]
        CorporateLlpDesignatedMember,

        [EnumMember(Value = "corporate-llp-member")]
        CorporateLlpMember,

        [EnumMember(Value = "corporate-manager-of-an-eeig")]
        CorporateManagerOfAnEeig,

        [EnumMember(Value = "corporate-member-of-a-management-organ")]
        CorporateMemberOfAManagementOrgan,

        [EnumMember(Value = "corporate-member-of-a-supervisory-organ")]
        CorporateMemberOfASupervisoryOrgan,

        [EnumMember(Value = "corporate-member-of-an-administrative-organ")]
        CorporateMemberOfAnAdministrativeOrgan,

        [EnumMember(Value = "corporate-nominee-director")]
        CorporateNomineeDirector,

        [EnumMember(Value = "corporate-nominee-secretary")]
        CorporateNomineeSecretary,

        [EnumMember(Value = "corporate-secretary")]
        CorporateSecretary,

        [EnumMember(Value = "director")]
        Director,

        [EnumMember(Value = "general-partner-in-a-limited-partnership")]
        GeneralPartnerInALimitedPartnership,

        [EnumMember(Value = "judicial-factor")]
        JudicialFactor,

        [EnumMember(Value = "limited-partner-in-a-limited-partnership")]
        LimitedPartnerInALimitedPartnership,

        [EnumMember(Value = "llp-designated-member")]
        LlpDesignatedMember,

        [EnumMember(Value = "llp-member")]
        LlpMember,

        [EnumMember(Value = "manager-of-an-eeig")]
        ManagerOfAnEeig,

        [EnumMember(Value = "member-of-a-management-organ")]
        MemberOfAManagementOrgan,

        [EnumMember(Value = "member-of-a-supervisory-organ")]
        MemberOfASupervisoryOrgan,

        [EnumMember(Value = "member-of-an-administrative-organ")]
        MemberOfAnAdministrativeOrgan,

        [EnumMember(Value = "nominee-director")]
        NomineeDirector,

        [EnumMember(Value = "nominee-secretary")]
        NomineeSecretary,

        [EnumMember(Value = "person-authorised-to-accept")]
        PersonAuthorisedToAccept,

        [EnumMember(Value = "person-authorised-to-represent")]
        PersonAuthorisedToRepresent,

        [EnumMember(Value = "person-authorised-to-represent-and-accept")]
        PersonAuthorisedToRepresentAndAccept,

        [EnumMember(Value = "receiver-and-manager")]
        ReceiverAndManager,

        [EnumMember(Value = "secretary")]
        Secretary
    }
}