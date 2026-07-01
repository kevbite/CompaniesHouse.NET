using System.Collections.Generic;
using CompaniesHouse.Response;
using CompaniesHouse.Response.CompanyProfile;
using CompaniesHouse.Response.Officers;
using CompaniesHouse.Response.PersonsWithSignificantControl;
using CompaniesHouse.Response.RegisteredOfficeAddress;

namespace CompaniesHouse.Tests
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
                {"micro-entity", LastAccountsType.MicroEntity},
                {"unaudited-abridged", LastAccountsType.UnauditedAbridged},
                {"audited-abridged", LastAccountsType.AuditedAbridged},
                {"no-accounts-type-available", LastAccountsType.NoAccountsTypeAvailable}
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
                {"converted-to-plc", CompanyStatusDetail.ConvertedToPlc},
                {"converted-to-ukeig", CompanyStatusDetail.ConvertedToUkeig},
                {"converted-to-uk-societas", CompanyStatusDetail.ConvertedToUkSocietas},
            };

        public static readonly IReadOnlyDictionary<string, Jurisdiction> PossibleJurisdictions = new Dictionary
            <string, Jurisdiction>()
            {
                {"england-wales", Jurisdiction.EnglandWales},
                {"wales", Jurisdiction.Wales},
                {"scotland", Jurisdiction.Scotland},
                {"northern-ireland", Jurisdiction.NorthernIreland},
                {"european-union", Jurisdiction.EuropeanUnion},
                {"united-kingdom", Jurisdiction.UnitedKingdom},
                {"england", Jurisdiction.England},
                {"noneu", Jurisdiction.Noneu}
            };

        public static readonly IReadOnlyDictionary<string, OfficerRole> PossibleOfficerRoles = new Dictionary
            <string, OfficerRole>()
            {
                {"cic-manager", OfficerRole.CicManager},
                {"corporate-director", OfficerRole.CorporateDirector},
                {"corporate-llp-designated-member", OfficerRole.CorporateLlpDesignatedMember},
                {"corporate-llp-member", OfficerRole.CorporateLlpMember},
                {"corporate-manager-of-an-eeig", OfficerRole.CorporateManagerOfAnEeig},
                {"corporate-managing-officer", OfficerRole.CorporateManagingOfficer},
                {"corporate-member-of-a-management-organ", OfficerRole.CorporateMemberOfAManagementOrgan},
                {"corporate-member-of-a-supervisory-organ", OfficerRole.CorporateMemberOfASupervisoryOrgan},
                {"corporate-member-of-an-administrative-organ", OfficerRole.CorporateMemberOfAnAdministrativeOrgan},
                {"corporate-nominee-director", OfficerRole.CorporateNomineeDirector},
                {"corporate-nominee-secretary", OfficerRole.CorporateNomineeSecretary},
                {"corporate-secretary", OfficerRole.CorporateSecretary},
                {"director", OfficerRole.Director},
                {"general-partner-in-a-limited-partnership", OfficerRole.GeneralPartnerInALimitedPartnership},
                {"corporate-general-partner-in-a-limited-partnership", OfficerRole.CorporateGeneralPartnerInALimitedPartnership},
                {"judicial-factor", OfficerRole.JudicialFactor},
                {"limited-partner-in-a-limited-partnership", OfficerRole.LimitedPartnerInALimitedPartnership},
                {"corporate-limited-partner-in-a-limited-partnership", OfficerRole.CorporateLimitedPartnerInALimitedPartnership},
                {"llp-designated-member", OfficerRole.LlpDesignatedMember},
                {"llp-member", OfficerRole.LlpMember},
                {"manager-of-an-eeig", OfficerRole.ManagerOfAnEeig},
                {"managing-officer", OfficerRole.ManagingOfficer},
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
                {"protected-cell-company", CompanyType.ProtectedCellCompany},
                {"assurance-company", CompanyType.AssuranceCompany},
                {"oversea-company", CompanyType.OverseaCompany},
                {"eeig-establishment", CompanyType.EeigEstablishment},
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
                {"european-public-limited-liability-company-se", CompanyType.EuropeanPublicLimitedLiabilityCompanySe},
                {"registered-society-non-jurisdictional", CompanyType.RegisteredSocietyNonJurisdictional},
                {"ukeig", CompanyType.Ukeig},
                {"united-kingdom-societas", CompanyType.UnitedKingdomSocietas},
                {"uk-establishment", CompanyType.UkEstablishment},
                {"scottish-partnership", CompanyType.ScottishPartnership},
                {"charitable-incorporated-organisation", CompanyType.CharitableIncorporatedOrganisation},
                {"scottish-charitable-incorporated-organisation", CompanyType.ScottishCharitableIncorporatedOrganisation},
                {"further-education-or-sixth-form-college-corporation", CompanyType.FurtherEducationOrSixthFormCollegeCorporation},
                {"registered-overseas-entity", CompanyType.RegisteredOverseasEntity},
            };

        public static readonly IReadOnlyDictionary<string, ResolutionCategory> PossibleResolutionCategories = new Dictionary
            <string, ResolutionCategory>()
            {
                {"miscellaneous", new ResolutionCategory("miscellaneous")}
            };

        public static readonly IReadOnlyDictionary<string, FilingHistoryStatus> PossibleFilingHistoryStatus = new Dictionary
            <string, FilingHistoryStatus>()
            {
                {"filing-history-available", new FilingHistoryStatus("filing-history-available")}
            };

        public static readonly IReadOnlyDictionary<string, FilingSubcategory> PossibleFilingSubcategories = new Dictionary
            <string, FilingSubcategory>()
            {
                {"annual-return", new FilingSubcategory("annual-return")},
                {"resolution", new FilingSubcategory("resolution")},
                {"change", new FilingSubcategory("change")},
                {"create", new FilingSubcategory("create")},
                {"certificate", new FilingSubcategory("certificate")},
                {"appointments", new FilingSubcategory("appointments")},
                {"satisfy", new FilingSubcategory("satisfy")},
                {"termination", new FilingSubcategory("termination")},
                {"release-cease", new FilingSubcategory("release-cease")},
                {"voluntary", new FilingSubcategory("voluntary")},
                {"administration", new FilingSubcategory("administration")},
                {"compulsory", new FilingSubcategory("compulsory")},
                {"court-order", new FilingSubcategory("court-order")},
                {"other", new FilingSubcategory("other")},
                {"notifications", new FilingSubcategory("notifications")},
                {"officers", new FilingSubcategory("officers")},
                {"document-replacement", new FilingSubcategory("document-replacement")},
                {"statements", new FilingSubcategory("statements")},
                {"voluntary-arrangement", new FilingSubcategory("voluntary-arrangement")},
                {"alter", new FilingSubcategory("alter")},
                {"register", new FilingSubcategory("register")},
                {"receiver", new FilingSubcategory("receiver")},
                {"voluntary-arrangement-moratoria", new FilingSubcategory("voluntary-arrangement-moratoria")},
                {"acquire", new FilingSubcategory("acquire")},
                {"trustee", new FilingSubcategory("trustee")},
                {"mortgage", new FilingSubcategory("mortgage")},
                {"transfer", new FilingSubcategory("transfer")},
                {"debenture", new FilingSubcategory("debenture")},
            };

        public static readonly IReadOnlyDictionary<string, FilingCategory> PossibleFilingCategories = new Dictionary
            <string, FilingCategory>()
            {
                {"accounts", new FilingCategory("accounts")},
                {"address", new FilingCategory("address")},
                {"annual-return", new FilingCategory("annual-return")},
                {"capital", new FilingCategory("capital")},
                {"change-of-name", new FilingCategory("change-of-name")},
                {"incorporation", new FilingCategory("incorporation")},
                {"liquidation", new FilingCategory("liquidation")},
                {"miscellaneous", new FilingCategory("miscellaneous")},
                {"mortgage", new FilingCategory("mortgage")},
                {"officers", new FilingCategory("officers")},
                {"resolution", new FilingCategory("resolution")},
                {"confirmation-statement", new FilingCategory("confirmation-statement")},
                {"persons-with-significant-control", new FilingCategory("persons-with-significant-control")},
                {"restoration", new FilingCategory("restoration")},
                {"return", new FilingCategory("return")},
                {"other", new FilingCategory("other")},
                {"reregistration", new FilingCategory("reregistration")},
                {"certificate", new FilingCategory("certificate")},
            };

        public static readonly IReadOnlyDictionary<string, PersonWithSignificantControlKind> PossiblePersonWithSignificantControlKinds = new Dictionary
            <string, PersonWithSignificantControlKind>()
            {
                {"corporate-entity-person-with-significant-control", new PersonWithSignificantControlKind("corporate-entity-person-with-significant-control")},
                {"individual-person-with-significant-control", new PersonWithSignificantControlKind("individual-person-with-significant-control")},
                {"super-secure-person-with-significant-control", new PersonWithSignificantControlKind("super-secure-person-with-significant-control")},
                {"legal-person-person-with-significant-control", new PersonWithSignificantControlKind("legal-person-person-with-significant-control")},
            };

        public static readonly IReadOnlyDictionary<string, AssetsCeasedReleased> PossibleAssetsCeasedReleased = new Dictionary<string, AssetsCeasedReleased>
        {
            {"property-ceased-to-belong", new AssetsCeasedReleased("property-ceased-to-belong")},
            {"part-property-release-and-ceased-to-belong", new AssetsCeasedReleased("part-property-release-and-ceased-to-belong")},
            {"part-property-released", new AssetsCeasedReleased("part-property-released")},
            {"part-property-ceased-to-belong", new AssetsCeasedReleased("part-property-ceased-to-belong")},
            {"whole-property-released", new AssetsCeasedReleased("whole-property-released")},
            {"multiple-filings", new AssetsCeasedReleased("multiple-filings")},
            {"whole-property-released-and-ceased-to-belong", new AssetsCeasedReleased("whole-property-released-and-ceased-to-belong")}
        };

        public static readonly IReadOnlyDictionary<string, ParticularType> PossibleParticularTypes = new Dictionary<string, ParticularType>
        {
            {"short-particulars", new ParticularType("short-particulars")},
            {"charged-property-description", new ParticularType("charged-property-description")},
            {"charged-property-or-undertaking-description", new ParticularType("charged-property-or-undertaking-description")},
            {"brief-description", new ParticularType("brief-description")}
        };

        public static readonly IReadOnlyDictionary<string, ClassificationChargeType> PossibleClassificationChargeTypes = new Dictionary<string, ClassificationChargeType>
        {
            {"charge-description", new ClassificationChargeType("charge-description")},
            {"nature-of-charge", new ClassificationChargeType("nature-of-charge")}
        };

        public static readonly IReadOnlyDictionary<string, SecuredDetailType> PossibleSecuredDetailTypes = new Dictionary<string, SecuredDetailType>
        {
            {"amount-secured", new SecuredDetailType("amount-secured")},
            {"obligations-secured", new SecuredDetailType("obligations-secured")},
        };

        public static readonly IReadOnlyDictionary<string, ChargeStatus> PossibleChargeStatuses = new Dictionary<string, ChargeStatus>
        {
            {"outstanding", new ChargeStatus("outstanding")},
            {"fully-satisfied", new ChargeStatus("fully-satisfied")},
            {"part-satisfied", new ChargeStatus("part-satisfied")},
            {"satisfied", new ChargeStatus("satisfied")}
        };

        public static readonly IReadOnlyDictionary<string, string> PossibleRegisteredOfficeAddressCountry = new Dictionary<string, string>
        {
            {"England", "England"},
            {"Scotland", "Scotland"},
            {"Wales", "Wales"},
            {"Great Britain", "Great Britain"},
            {"Northern Ireland", "Northern Ireland"},
            {"Not specified", "Not specified"},
            {"United Kingdom", "United Kingdom"}
        };
    }
}