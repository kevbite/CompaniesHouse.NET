using System.Runtime.Serialization;

namespace CompaniesHouse.Response
{
    public enum SecuredDetailType
    {
        [EnumMember(Value = "")]
        None = 0, 
        
        [EnumMember(Value = "amount-secured")] 
        AmountSecured,

        [EnumMember(Value = "obligations-secured")]
        ObligationsSecured
    }
}