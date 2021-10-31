using System.Runtime.Serialization;

namespace CompaniesHouse.Response.RegisteredOfficeAddress
{
    public enum OfficeAddressCountry
    {
        [EnumMember(Value = "Not specified")]
        NotSpecified = 0, 
        
        [EnumMember(Value = "England")]
        England,
        
        [EnumMember(Value = "Wales")]
        Wales,
        
        [EnumMember(Value = "Scotland")]
        Scotland,
        
        [EnumMember(Value = "Northern Ireland")]
        NorthernIreland,
        
        [EnumMember(Value = "Great Britain")]
        GreatBritain,
        
        [EnumMember(Value = "United Kingdom")]
        UnitedKingdom
    }
}