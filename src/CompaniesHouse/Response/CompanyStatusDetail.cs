using System.Runtime.Serialization;

namespace CompaniesHouse.Response
{
    public enum CompanyStatusDetail
    {
        None = 0,

        [EnumMember(Value = "transferred-from-uk")]
        TransferredFromUk,

        [EnumMember(Value = "active-proposal-to-strike-off")]
        ActiveProposalToStrikeOff,

        [EnumMember(Value = "petition-to-restore-dissolved")]
        PetitionToRestoreDissolved,

        [EnumMember(Value = "transformed-to-se")]
        TransformedToSe,

        [EnumMember(Value = "converted-to-plc")]
        ConvertedToPlc,

        [EnumMember(Value = "converted-to-ukeig")]
        ConvertedToUnitedKingdomEconomicInterestGroupings,

        [EnumMember(Value = "converted-to-uk-societas")]
        ConvertedToUnitedKingdomSocietas
    }
}