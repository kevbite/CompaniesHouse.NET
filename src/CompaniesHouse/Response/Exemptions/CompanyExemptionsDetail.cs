using System.Text.Json.Serialization;

namespace CompaniesHouse.Response.Exemptions
{
    public class CompanyExemptionsDetail
    {
        [JsonPropertyName("psc_exempt_as_trading_on_regulated_market")]
        public CompanyExemptionsCategory? PscExemptAsTradingOnRegulatedMarket { get; set; }

        [JsonPropertyName("psc_exempt_as_shares_admitted_on_market")]
        public CompanyExemptionsCategory? PscExemptAsSharesAdmittedOnMarket { get; set; }

        [JsonPropertyName("psc_exempt_as_trading_on_uk_regulated_market")]
        public CompanyExemptionsCategory? PscExemptAsTradingOnUkRegulatedMarket { get; set; }

        [JsonPropertyName("psc_exempt_as_trading_on_eu_regulated_market")]
        public CompanyExemptionsCategory? PscExemptAsTradingOnEuRegulatedMarket { get; set; }

        [JsonPropertyName("disclosure_transparency_rules_chapter_five_applies")]
        public CompanyExemptionsCategory? DisclosureTransparencyRulesChapterFiveApplies { get; set; }
    }
}
