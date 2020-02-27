using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CompaniesHouse.Response.Insolvency
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum InsolvencyStatus
    {
        [EnumMember(Value = "")]
        None = 0,

        [EnumMember(Value = "live-propopsed-transfer-from-gb")]
        LivepropopsedTransferFromGb,

        [EnumMember(Value = "voluntary-arrangement")]
        VoluntaryArrangement,

        [EnumMember(Value = "voluntary-arrangement-receivership")]
        VoluntaryArrangementReceivership,

        [EnumMember(Value = "administration-order")]
        AdministrationOrder,

        [EnumMember(Value = "live-receiver-manager-on-at-least-one-charge")]
        LiveReceiverManagerOnAtLeastOneCharge,

        [EnumMember(Value = "administrative-receiver")]
        AdministrativeReceiver,

        [EnumMember(Value = "receiver-manager-or-administrative-receiver")]
        ReceiverManagerOrAdministrativeReceiver,

        [EnumMember(Value = "receiver-manager")]
        ReceiverManager,

        [EnumMember(Value = "receivership")]
        Receivership,

        [EnumMember(Value = "in-administration")]
        InAdministration,

        [EnumMember(Value = "liquidation")]
        Liquidation,
    }
}