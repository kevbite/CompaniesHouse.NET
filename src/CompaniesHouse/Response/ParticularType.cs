using System.Runtime.Serialization;

namespace CompaniesHouse.Response
{
    public enum ParticularType
    {
        [EnumMember(Value = "")] 
        None = 0,

        [EnumMember(Value = "short-particulars")]
        ShortParticulars,

        [EnumMember(Value = "charged-property-description")]
        ChargedPropertyDescription,

        [EnumMember(Value = "charged-property-or-undertaking-description")]
        ChargedPropertyOrUndertakingDescription,

        [EnumMember(Value = "brief-description")]
        BriefDescription
    }
}