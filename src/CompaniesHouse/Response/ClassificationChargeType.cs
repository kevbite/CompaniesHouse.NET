using System.Runtime.Serialization;

namespace CompaniesHouse.Response
{
    public enum ClassificationChargeType
    {
        [EnumMember(Value = "")]
        None = 0,
        
        [EnumMember(Value="charge-description")]
        ChargeDescription,
        
        [EnumMember(Value="nature-of-charge")]
        NatureOfCharge
    }
}