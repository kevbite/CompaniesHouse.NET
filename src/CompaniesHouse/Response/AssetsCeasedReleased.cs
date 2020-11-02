using System.Runtime.Serialization;

namespace CompaniesHouse.Response
{
    public enum AssetsCeasedReleased
    {
        [EnumMember(Value = "")]
        None = 0,
        
        [EnumMember(Value = "property-ceased-to-belong")]
        PropertyCeasedToBelong,

        [EnumMember(Value = "part-property-release-and-ceased-to-belong")]
        PartPropertyReleaseAndCeasedToBelong,

        [EnumMember(Value = "part-property-released")]
        PartPropertyReleased,

        [EnumMember(Value = "part-property-ceased-to-belong")]
        PartPropertyCeasedToBelong,

        [EnumMember(Value = "whole-property-released")]
        WholePropertyReleased,

        [EnumMember(Value = "multiple-filings")]
        MultipleFilings,

        [EnumMember(Value = "whole-property-released-and-ceased-to-belong")]
        WholePropertyReleasedAndCeasedToBelong
    }
}