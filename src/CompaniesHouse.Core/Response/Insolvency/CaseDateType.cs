using System.Runtime.Serialization;

namespace CompaniesHouse.Core.Response.Insolvency
{
    public enum CaseDateType
    {
        [EnumMember(Value = "")]
        None = 0,

        [EnumMember(Value = "instrumented-on")]
        InstrumentedOn,
        
        [EnumMember(Value = "administration-started-on")]
        AdministrationStartedOn,
        
        [EnumMember(Value = "administration-discharged-on")]
        AdministrationDischargedOn,
        
        [EnumMember(Value = "administration-ended-on")]
        AdministrationEndedOn,
        
        [EnumMember(Value = "concluded-winding-up-on")]
        ConcludedWindingUpOn,
        
        [EnumMember(Value = "petitioned-on")]
        PetitionedOn,

        [EnumMember(Value = "ordered-to-wind-up-on")]
        OrderedToWindUpOn,

        [EnumMember(Value = "due-to-be-dissolved-on")]
        DueToBeDissolvedOn,

        [EnumMember(Value = "case-end-on")]
        CaseEndOn,

        [EnumMember(Value = "wound-up-on")]
        WoundUpOn,

        [EnumMember(Value = "voluntary-arrangement-started-on")]
        VoluntaryArrangementStartedOn,
        
        [EnumMember(Value = "voluntary-arrangement-ended-on")]
        VoluntaryArrangementEndedOn,
        
        [EnumMember(Value = "moratorium-started-on")]
        MoratoriumStartedOn,

        [EnumMember(Value = "moratorium-ended-on")]
        MoratoriumEndedOn,

        [EnumMember(Value = "declaration-solvent-on")]
        DeclarationSolventOn,

        [EnumMember(Value = "dissolved-on")]
        DissolvedOn,
    }
}