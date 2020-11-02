using System.Runtime.Serialization;

namespace CompaniesHouse.Response
{
    public enum ChargeStatus
    {
        [EnumMember(Value = "")]
        None = 0,
    
        [EnumMember(Value = "outstanding")]
        Outstanding,
        
        [EnumMember(Value = "fully-satisfied")]
        FullySatisfied,
        
        [EnumMember(Value = "part-satisfied")]
        PartSatisfied,
        
        [EnumMember(Value = "satisfied")]
        Satisfied,
    }
}