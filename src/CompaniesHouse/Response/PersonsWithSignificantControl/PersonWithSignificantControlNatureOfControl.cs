using System.Runtime.Serialization;

namespace CompaniesHouse.Response.PersonsWithSignificantControl
{
    public enum PersonWithSignificantControlNatureOfControl
    {
        [EnumMember(Value = "ownership-of-shares-25-to-50-percent")]
        OwnershipOfShares25To50Percent,
        [EnumMember(Value = "ownership-of-shares-50-to-75-percent")]
        OwnershipOfShares50To75Percent,
        [EnumMember(Value = "ownership-of-shares-75-to-100-percent")]
        OwnershipOfShares75To100Percent,
        [EnumMember(Value = "ownership-of-shares-25-to-50-percent-as-trust")]
        OwnershipOfShares25To50PercentAsTrust,
        [EnumMember(Value = "ownership-of-shares-50-to-75-percent-as-trust")]
        OwnershipOfShares50To75PercentAsTrust,
        [EnumMember(Value = "ownership-of-shares-75-to-100-percent-as-trust")]
        OwnershipOfShares75To100PercentAsTrust,
        [EnumMember(Value = "ownership-of-shares-25-to-50-percent-as-firm")]
        OwnershipOfShares25To50PercentAsFirm,
        [EnumMember(Value = "ownership-of-shares-50-to-75-percent-as-firm")]
        OwnershipOfShares50To75PercentAsFirm,
        [EnumMember(Value = "ownership-of-shares-75-to-100-percent-as-firm")]
        OwnershipOfShares75To100PercentAsFirm,
        [EnumMember(Value = "ownership-of-shares-more-than-25-percent-registered-overseas-entity")]
        OwnershipOfSharesMoreThan25PercentRegisteredOverseasEntity,
        [EnumMember(Value = "ownership-of-shares-more-than-25-percent-as-trust-registered-overseas-entity")]
        OwnershipOfSharesMoreThan25PercentAsTrustRegisteredOverseasEntity,
        [EnumMember(Value = "ownership-of-shares-more-than-25-percent-as-firm-registered-overseas-entity")]
        OwnershipOfSharesMoreThan25PercentAsFirmRegisteredOverseasEntity,
        [EnumMember(Value = "voting-rights-25-to-50-percent")]
        VotingRights25To50Percent,
        [EnumMember(Value = "voting-rights-50-to-75-percent")]
        VotingRights50To75Percent,
        [EnumMember(Value = "voting-rights-75-to-100-percent")]
        VotingRights75To100Percent,
        [EnumMember(Value = "voting-rights-25-to-50-percent-as-trust")]
        VotingRights25To50PercentAsTrust,
        [EnumMember(Value = "voting-rights-50-to-75-percent-as-trust")]
        VotingRights50To75PercentAsTrust,
        [EnumMember(Value = "voting-rights-75-to-100-percent-as-trust")]
        VotingRights75To100PercentAsTrust,
        [EnumMember(Value = "voting-rights-25-to-50-percent-as-firm")]
        VotingRights25To50PercentAsFirm,
        [EnumMember(Value = "voting-rights-50-to-75-percent-as-firm")]
        VotingRights50To75PercentAsFirm,
        [EnumMember(Value = "voting-rights-75-to-100-percent-as-firm")]
        VotingRights75To100PercentAsFirm,
        [EnumMember(Value = "voting-rights-more-than-25-percent-registered-overseas-entity")]
        VotingRightsMoreThan25PercentRegisteredOverseasEntity,
        [EnumMember(Value = "voting-rights-more-than-25-percent-as-trust-registered-overseas-entity")]
        VotingRightsMoreThan25PercentAsTrustRegisteredOverseasEntity,
        [EnumMember(Value = "voting-rights-more-than-25-percent-as-firm-registered-overseas-entity")]
        VotingRightsMoreThan25PercentAsFirmRegisteredOverseasEntity,
        [EnumMember(Value = "right-to-appoint-and-remove-directors")]
        RightToAppointAndRemoveDirectors,
        [EnumMember(Value = "right-to-appoint-and-remove-directors-as-trust")]
        RightToAppointAndRemoveDirectorsAsTrust,
        [EnumMember(Value = "right-to-appoint-and-remove-directors-as-firm")]
        RightToAppointAndRemoveDirectorsAsFirm,
        [EnumMember(Value = "significant-influence-or-control")]
        SignificantInfluenceOrControl,
        [EnumMember(Value = "significant-influence-or-control-as-trust")]
        SignificantInfluenceOrControlAsTrust,
        [EnumMember(Value = "significant-influence-or-control-as-firm")]
        SignificantInfluenceOrControlAsFirm,
        [EnumMember(Value = "right-to-share-surplus-assets-25-to-50-percent-limited-liability-partnership")]
        RightToShareSurplusAssets25To50PercentLimitedLiabilityPartnership,
        [EnumMember(Value = "right-to-share-surplus-assets-50-to-75-percent-limited-liability-partnership")]
        RightToShareSurplusAssets50To75PercentLimitedLiabilityPartnership,
        [EnumMember(Value = "right-to-share-surplus-assets-75-to-100-percent-limited-liability-partnership")]
        RightToShareSurplusAssets75To100PercentLimitedLiabilityPartnership,
        [EnumMember(Value = "right-to-share-surplus-assets-25-to-50-percent-as-trust-limited-liability-partnership")]
        RightToShareSurplusAssets25To50PercentAsTrustLimitedLiabilityPartnership,
        [EnumMember(Value = "right-to-share-surplus-assets-50-to-75-percent-as-trust-limited-liability-partnership")]
        RightToShareSurplusAssets50To75PercentAsTrustLimitedLiabilityPartnership,
        [EnumMember(Value = "right-to-share-surplus-assets-75-to-100-percent-as-trust-limited-liability-partnership")]
        RightToShareSurplusAssets75To100PercentAsTrustLimitedLiabilityPartnership,
        [EnumMember(Value = "right-to-share-surplus-assets-25-to-50-percent-as-firm-limited-liability-partnership")]
        RightToShareSurplusAssets25To50PercentAsFirmLimitedLiabilityPartnership,
        [EnumMember(Value = "right-to-share-surplus-assets-50-to-75-percent-as-firm-limited-liability-partnership")]
        RightToShareSurplusAssets50To75PercentAsFirmLimitedLiabilityPartnership,
        [EnumMember(Value = "right-to-share-surplus-assets-75-to-100-percent-as-firm-limited-liability-partnership")]
        RightToShareSurplusAssets75To100PercentAsFirmLimitedLiabilityPartnership,
        [EnumMember(Value = "voting-rights-25-to-50-percent-limited-liability-partnership")]
        VotingRights25To50PercentLimitedLiabilityPartnership,
        [EnumMember(Value = "voting-rights-50-to-75-percent-limited-liability-partnership")]
        VotingRights50To75PercentLimitedLiabilityPartnership,
        [EnumMember(Value = "voting-rights-75-to-100-percent-limited-liability-partnership")]
        VotingRights75To100PercentLimitedLiabilityPartnership,
        [EnumMember(Value = "voting-rights-25-to-50-percent-as-trust-limited-liability-partnership")]
        VotingRights25To50PercentAsTrustLimitedLiabilityPartnership,
        [EnumMember(Value = "voting-rights-50-to-75-percent-as-trust-limited-liability-partnership")]
        VotingRights50To75PercentAsTrustLimitedLiabilityPartnership,
        [EnumMember(Value = "voting-rights-75-to-100-percent-as-trust-limited-liability-partnership")]
        VotingRights75To100PercentAsTrustLimitedLiabilityPartnership,
        [EnumMember(Value = "voting-rights-25-to-50-percent-as-firm-limited-liability-partnership")]
        VotingRights25To50PercentAsFirmLimitedLiabilityPartnership,
        [EnumMember(Value = "voting-rights-50-to-75-percent-as-firm-limited-liability-partnership")]
        VotingRights50To75PercentAsFirmLimitedLiabilityPartnership,
        [EnumMember(Value = "voting-rights-75-to-100-percent-as-firm-limited-liability-partnership")]
        VotingRights75To100PercentAsFirmLimitedLiabilityPartnership,
        [EnumMember(Value = "right-to-appoint-and-remove-members-limited-liability-partnership")]
        RightToAppointAndRemoveMembersLimitedLiabilityPartnership,
        [EnumMember(Value = "right-to-appoint-and-remove-members-as-trust-limited-liability-partnership")]
        RightToAppointAndRemoveMembersAsTrustLimitedLiabilityPartnership,
        [EnumMember(Value = "right-to-appoint-and-remove-members-as-firm-limited-liability-partnership")]
        RightToAppointAndRemoveMembersAsFirmLimitedLiabilityPartnership,
        [EnumMember(Value = "significant-influence-or-control-limited-liability-partnership")]
        SignificantInfluenceOrControlLimitedLiabilityPartnership,
        [EnumMember(Value = "significant-influence-or-control-as-trust-limited-liability-partnership")]
        SignificantInfluenceOrControlAsTrustLimitedLiabilityPartnership,
        [EnumMember(Value = "significant-influence-or-control-as-firm-limited-liability-partnership")]
        SignificantInfluenceOrControlAsFirmLimitedLiabilityPartnership,
        [EnumMember(Value = "significant-influence-or-control-registered-overseas-entity")]
        SignificantInfluenceOrControlRegisteredOverseasEntity,
        [EnumMember(Value = "significant-influence-or-control-as-trust-registered-overseas-entity")]
        SignificantInfluenceOrControlAsTrustRegisteredOverseasEntity,
        [EnumMember(Value = "significant-influence-or-control-as-firm-registered-overseas-entity")]
        SignificantInfluenceOrControlAsFirmRegisteredOverseasEntity,
        [EnumMember(Value = "part-right-to-share-surplus-assets-25-to-50-percent")]
        PartRightToShareSurplusAssets25To50Percent,
        [EnumMember(Value = "part-right-to-share-surplus-assets-50-to-75-percent")]
        PartRightToShareSurplusAssets50To75Percent,
        [EnumMember(Value = "part-right-to-share-surplus-assets-75-to-100-percent")]
        PartRightToShareSurplusAssets75To100Percent,
        [EnumMember(Value = "part-right-to-share-surplus-assets-25-to-50-percent-as-trust")]
        PartRightToShareSurplusAssets25To50PercentAsTrust,
        [EnumMember(Value = "part-right-to-share-surplus-assets-50-to-75-percent-as-trust")]
        PartRightToShareSurplusAssets50To75PercentAsTrust,
        [EnumMember(Value = "part-right-to-share-surplus-assets-75-to-100-percent-as-trust")]
        PartRightToShareSurplusAssets75To100PercentAsTrust,
        [EnumMember(Value = "part-right-to-share-surplus-assets-25-to-50-percent-as-firm")]
        PartRightToShareSurplusAssets25To50PercentAsFirm,
        [EnumMember(Value = "part-right-to-share-surplus-assets-50-to-75-percent-as-firm")]
        PartRightToShareSurplusAssets50To75PercentAsFirm,
        [EnumMember(Value = "part-right-to-share-surplus-assets-75-to-100-percent-as-firm")]
        PartRightToShareSurplusAssets75To100PercentAsFirm,
        [EnumMember(Value = "right-to-appoint-and-remove-person")]
        RightToAppointAndRemovePerson,
        [EnumMember(Value = "right-to-appoint-and-remove-person-as-firm")]
        RightToAppointAndRemovePersonAsFirm,
        [EnumMember(Value = "right-to-appoint-and-remove-person-as-trust")]
        RightToAppointAndRemovePersonAsTrust,
        [EnumMember(Value = "right-to-appoint-and-remove-directors-registered-overseas-entity")]
        RightToAppointAndRemoveDirectorsRegisteredOverseasEntity,
        [EnumMember(Value = "right-to-appoint-and-remove-directors-as-trust-registered-overseas-entity")]
        RightToAppointAndRemoveDirectorsAsTrustRegisteredOverseasEntity,
        [EnumMember(Value = "right-to-appoint-and-remove-directors-as-firm-registered-overseas-entity")]
        RightToAppointAndRemoveDirectorsAsFirmRegisteredOverseasEntity,
    }
}