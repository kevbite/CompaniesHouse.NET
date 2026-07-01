using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CompaniesHouse.JsonConverters;

namespace CompaniesHouse.Response
{
    /// <summary>
    /// The status of a company, as returned by the Companies House API.
    /// </summary>
    /// <remarks>
    /// This is a string-backed value type rather than a plain C# <see langword="enum"/>.
    /// Companies House do not reliably version their API, so new status values can
    /// appear in responses at any time. A string-backed type preserves the raw wire
    /// value and never throws on an unrecognised value — see
    /// <see href="https://kevsoft.net/2026/06/28/enums-in-api-contracts.html"/>.
    /// </remarks>
    [JsonConverter(typeof(CompanyStatusJsonConverter))]
    public readonly record struct CompanyStatus
    {
        private readonly string? _value;

        public CompanyStatus(string? value)
        {
            _value = value;
        }

        /// <summary>
        /// The raw wire value. Never <see langword="null"/> — an absent/unknown
        /// value is represented as <see cref="string.Empty"/>; see <see cref="HasValue"/>.
        /// </summary>
        public string Value => _value ?? string.Empty;

        /// <summary>
        /// <see langword="true"/> if a value was present on the wire (including any
        /// unrecognised value); <see langword="false"/> for the <see langword="default"/>/absent case.
        /// </summary>
        public bool HasValue => !string.IsNullOrEmpty(_value);

        /// <summary>
        /// <see langword="true"/> if <see cref="Value"/> is one of the values known to this
        /// version of the library at the time of writing.
        /// </summary>
        public bool IsKnown => KnownValues.Contains(Value);

        /// <summary>
        /// The human-readable description of <see cref="Value"/>, sourced from the
        /// Companies House <c>api-enumerations</c> reference data, or <see langword="null"/>
        /// if no description is known for this value.
        /// </summary>
        public string? Description => Descriptions.TryGetValue(Value, out var description) ? description : null;

        public static CompanyStatus Active => new("active");
        public static CompanyStatus Dissolved => new("dissolved");
        public static CompanyStatus Liquidation => new("liquidation");
        public static CompanyStatus Receivership => new("receivership");
        public static CompanyStatus Administration => new("administration");
        public static CompanyStatus VoluntaryArrangement => new("voluntary-arrangement");
        public static CompanyStatus ConvertedClosed => new("converted-closed");
        public static CompanyStatus InsolvencyProceedings => new("insolvency-proceedings");
        public static CompanyStatus Open => new("open");
        public static CompanyStatus Closed => new("closed");
        public static CompanyStatus ClosedOn => new("closed-on");
        public static CompanyStatus Registered => new("registered");
        public static CompanyStatus Removed => new("removed");

        public override string ToString() => Value;

        private static readonly HashSet<string> KnownValues = new(StringComparer.Ordinal)
        {
            "active",
            "dissolved",
            "liquidation",
            "receivership",
            "administration",
            "voluntary-arrangement",
            "converted-closed",
            "insolvency-proceedings",
            "open",
            "closed",
            "closed-on",
            "registered",
            "removed",
        };

        // Sourced from https://github.com/companieshouse/api-enumerations constants.yml (company_status).
        private static readonly IReadOnlyDictionary<string, string> Descriptions = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["active"] = "Active",
            ["dissolved"] = "Dissolved",
            ["liquidation"] = "Liquidation",
            ["receivership"] = "Receiver Action",
            ["converted-closed"] = "Converted / Closed",
            ["voluntary-arrangement"] = "Voluntary Arrangement",
            ["insolvency-proceedings"] = "Insolvency Proceedings",
            ["administration"] = "In Administration",
            ["open"] = "Open",
            ["closed"] = "Closed",
            ["registered"] = "Registered",
            ["removed"] = "Removed",
        };
    }
}
