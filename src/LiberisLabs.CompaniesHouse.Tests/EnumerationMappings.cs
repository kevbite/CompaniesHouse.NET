using System.Collections.Generic;
using LiberisLabs.CompaniesHouse.Response;
using LiberisLabs.CompaniesHouse.Response.CompanyProfile;

namespace LiberisLabs.CompaniesHouse.Tests
{
    public static class EnumerationMappings
    {

        public static readonly IReadOnlyDictionary<string, LastAccountsType> PossibleLastAccountsTypes = new Dictionary
            <string, LastAccountsType>()
        {
            {"null", LastAccountsType.Null},
            {"full", LastAccountsType.Full},
            {"small", LastAccountsType.Small},
            {"medium", LastAccountsType.Medium},
            {"group", LastAccountsType.Group},
            {"dormant", LastAccountsType.Dormant},
            {"interim", LastAccountsType.Interim},
            {"initial", LastAccountsType.Initial},
            {"total-exemption-full", LastAccountsType.TotalExemptionFull},
            {"total-exemption-small", LastAccountsType.TotalExemptionSmall},
            {"partial-exemption", LastAccountsType.PartialExemption},
            {"audit-exemption-subsidiary", LastAccountsType.AuditExemptionSubsidiary},
            {"filing-exemption-subsidiary", LastAccountsType.FilingExemptionSubsidiary},
            {"micro-entity", LastAccountsType.MicroEntity}
        };

        public static readonly IReadOnlyDictionary<string, CompanyStatus> PossibleCompanyStatuses = new Dictionary
            <string, CompanyStatus>()
        {
            {"active", CompanyStatus.Active},
            {"dissolved", CompanyStatus.Dissolved},
            {"liquidation", CompanyStatus.Liquidation},
            {"receivership", CompanyStatus.Receivership},
            {"administration", CompanyStatus.Administration},
            {"voluntary-arrangement", CompanyStatus.VoluntaryArrangement},
            {"converted-closed", CompanyStatus.ConvertedClosed},
            {"insolvency-proceedings", CompanyStatus.InsolvencyProceedings}
        };

        public static readonly IReadOnlyDictionary<string, CompanyStatusDetail> PossibleCompanyStatusDetails = new Dictionary
            <string, CompanyStatusDetail>()
        {
            {"transferred-from-uk", CompanyStatusDetail.TransferredFromUk},
            {"active-proposal-to-strike-off", CompanyStatusDetail.ActiveProposalToStrikeOff},
            {"petition-to-restore-dissolved", CompanyStatusDetail.PetitionToRestoreDissolved},
            {"transformed-to-se", CompanyStatusDetail.TransformedToSe},
            {"converted-to-plc", CompanyStatusDetail.ConvertedToPlc}
        };

        public static readonly IReadOnlyDictionary<string, Jurisdiction> PossibleJurisdictions = new Dictionary
            <string, Jurisdiction>()
        {
            {"england-wales", Jurisdiction.EnglandAndWales},
            {"wales", Jurisdiction.Wales},
            {"scotland", Jurisdiction.Scotland},
            {"northern-ireland", Jurisdiction.NorthernIreland},
            {"european-union", Jurisdiction.EuropeanUnion},
            {"united-kingdom", Jurisdiction.UnitedKingdom},
            {"england", Jurisdiction.England},
            {"noneu", Jurisdiction.NonEu}
        };

        public static readonly IReadOnlyDictionary<string, OfficerRole> PossibleOfficerRoles = new Dictionary
            <string, OfficerRole>()
        {
            {"cic-manager", OfficerRole.CicManager},
            {"corporate-director", OfficerRole.CorporateDirector},
            {"corporate-llp-designated-member", OfficerRole.CorporateLlpDesignatedMember},
            {"corporate-llp-member", OfficerRole.CorporateLlpMember},
            {"corporate-manager-of-an-eeig", OfficerRole.CorporateManagerOfAnEeig},
            {"corporate-member-of-a-management-organ", OfficerRole.CorporateMemberOfAManagementOrgan},
            {"corporate-member-of-a-supervisory-organ", OfficerRole.CorporateMemberOfASupervisoryOrgan},
            {"corporate-member-of-an-administrative-organ", OfficerRole.CorporateMemberOfAnAdministrativeOrgan},
            {"corporate-nominee-director", OfficerRole.CorporateNomineeDirector},
            {"corporate-nominee-secretary", OfficerRole.CorporateNomineeSecretary},
            {"corporate-secretary", OfficerRole.CorporateSecretary},
            {"director", OfficerRole.Director},
            {"general-partner-in-a-limited-partnership", OfficerRole.GeneralPartnerInALimitedPartnership},
            {"judicial-factor", OfficerRole.JudicialFactor},
            {"limited-partner-in-a-limited-partnership", OfficerRole.LimitedPartnerInALimitedPartnership},
            {"llp-designated-member", OfficerRole.LlpDesignatedMember},
            {"llp-member", OfficerRole.LlpMember},
            {"manager-of-an-eeig", OfficerRole.ManagerOfAnEeig},
            {"member-of-a-management-organ", OfficerRole.MemberOfAManagementOrgan},
            {"member-of-a-supervisory-organ", OfficerRole.MemberOfASupervisoryOrgan},
            {"member-of-an-administrative-organ", OfficerRole.MemberOfAnAdministrativeOrgan},
            {"nominee-director", OfficerRole.NomineeDirector},
            {"nominee-secretary", OfficerRole.NomineeSecretary},
            {"person-authorised-to-accept", OfficerRole.PersonAuthorisedToAccept},
            {"person-authorised-to-represent", OfficerRole.PersonAuthorisedToRepresent},
            {"person-authorised-to-represent-and-accept", OfficerRole.PersonAuthorisedToRepresentAndAccept},
            {"receiver-and-manager", OfficerRole.ReceiverAndManager},
            {"secretary", OfficerRole.Secretary}
        };

        public static readonly IReadOnlyDictionary<string, CompanyType> ExpectedCompanyTypesMap = new Dictionary
            <string, CompanyType>()
        {
            {"private-unlimited", CompanyType.PrivateUnlimited},
            {"ltd", CompanyType.Ltd},
            {"plc", CompanyType.Plc},
            {"old-public-company", CompanyType.OldPublicCompany},
            {"private-limited-guarant-nsc-limited-exemption", CompanyType.PrivateLimitedGuarantNscLimitedExemption},
            {"limited-partnership", CompanyType.LimitedPartnership},
            {"private-limited-guarant-nsc", CompanyType.PrivateLimitedGuarantNsc},
            {"converted-or-closed", CompanyType.ConvertedOrClosed},
            {"private-unlimited-nsc", CompanyType.PrivateUnlimitedNsc},
            {"private-limited-shares-section-30-exemption", CompanyType.PrivateLimitedSharesSection30Exemption},
            {"assurance-company", CompanyType.AssuranceCompany},
            {"oversea-company", CompanyType.OverseaCompany},
            {"eeig", CompanyType.Eeig},
            {"icvc-securities", CompanyType.IcvcSecurities},
            {"icvc-warrant", CompanyType.IcvcWarrant},
            {"icvc-umbrella", CompanyType.IcvcUmbrella},
            {"industrial-and-provident-society", CompanyType.IndustrialAndProvidentSociety},
            {"northern-ireland", CompanyType.NorthernIreland},
            {"northern-ireland-other", CompanyType.NorthernIrelandOther},
            {"llp", CompanyType.Llp},
            {"royal-charter", CompanyType.RoyalCharter},
            {"investment-company-with-variable-capital", CompanyType.InvestmentCompanyWithVariableCapital},
            {"unregistered-company", CompanyType.UnregisteredCompany},
            {"other", CompanyType.Other},
            {"european-public-limited-liability-company-se", CompanyType.EuropeanPublicLimitedLiabilityCompanySe}
        };

        public static readonly IReadOnlyDictionary<string, ResolutionCategory> PossibleResolutionCategories = new Dictionary
            <string, ResolutionCategory>()
        {
            {"miscellaneous", ResolutionCategory.Miscellaneous}
        };

        public static readonly IReadOnlyDictionary<string, FilingHistoryStatus> PossibleFilingHistoryStatus = new Dictionary
            <string, FilingHistoryStatus>()
        {
            {"filing-history-available", FilingHistoryStatus.FilingHistoryAvailable}
        };

        public static readonly IReadOnlyDictionary<string, FilingSubcategory> PossibleFilingSubcategories = new Dictionary
            <string, FilingSubcategory>()
        {
            {"resolution", FilingSubcategory.Resolution}
        };

        public static readonly IReadOnlyDictionary<string, FilingCategory> PossibleFilingCategories = new Dictionary
            <string, FilingCategory>()
        {
            {"accounts", FilingCategory.Accounts},
            {"address", FilingCategory.Address},
            {"annual-return", FilingCategory.AnnualReturn},
            {"capital", FilingCategory.Capital},
            {"change-of-name", FilingCategory.ChangeOfName},
            {"incorporation", FilingCategory.Incorporation},
            {"liquidation", FilingCategory.Liquidation},
            {"miscellaneous", FilingCategory.Miscellaneous},
            {"mortgage", FilingCategory.Mortgage},
            {"officers", FilingCategory.Officers},
            {"resolution", FilingCategory.Resolution}
        };
    }
}