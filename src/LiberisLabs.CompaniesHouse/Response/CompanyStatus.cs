using System.Runtime.Serialization;

namespace LiberisLabs.CompaniesHouse.Response
{
    public enum CompanyStatus
    {
        [EnumMember(Value = "")]
        None = 0,

        [EnumMember(Value = "active")]
        Active,

        [EnumMember(Value = "dissolved")]
        Dissolved,

        [EnumMember(Value = "liquidation")]
        Liquidation,

        [EnumMember(Value = "receivership")]
        Receivership,

        [EnumMember(Value = "administration")]
        Administration,

        [EnumMember(Value = "voluntary-arrangement")]
        VoluntaryArrangement,

        [EnumMember(Value = "converted-closed")]
        ConvertedClosed,

        [EnumMember(Value = "insolvency-proceedings")]
        InsolvencyProceedings

    }


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
        ConvertedToPlc
    }
    
}
 