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
                {"converted-to-ukeig", CompanyStatusDetail.ConvertedToUnitedKingdomEconomicInterestGroupings},
                {"converted-to-uk-societas", CompanyStatusDetail.ConvertedToUnitedKingdomSocietas},
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
                {"corporate-managing-officer", OfficerRole.CorporateManagingOfficer},
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
                {"european-public-limited-liability-company-se", CompanyType.EuropeanPublicLimitedLiabilityCompanySe},
                {"registered-society-non-jurisdictional", CompanyType.RegisteredSociety},
                {"ukeig", CompanyType.UnitedKingdomEconomicInterestGroupings},
                {"united-kingdom-societas", CompanyType.UnitedKingdomSocietas},
                {"registered-overseas-entity", CompanyType.RegisteredOverseasEntity},
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
                {"annual-return", FilingSubcategory.AnnualReturn},
                {"resolution", FilingSubcategory.Resolution},
                {"change", FilingSubcategory.Change},
                {"create", FilingSubcategory.Create},
                {"certificate", FilingSubcategory.Certificate},
                {"appointments", FilingSubcategory.Appointments},
                {"satisfy", FilingSubcategory.Satisfy},
                {"termination", FilingSubcategory.Termination},
                {"release-cease", FilingSubcategory.ReleaseCease},
                {"voluntary", FilingSubcategory.Voluntary},
                {"administration", FilingSubcategory.Administration},
                {"compulsory", FilingSubcategory.Compulsory},
                {"court-order", FilingSubcategory.CourtOrder},
                {"other", FilingSubcategory.Other},
                {"notifications", FilingSubcategory.Notifications},
                {"officers", FilingSubcategory.Officers},
                {"document-replacement", FilingSubcategory.DocumentReplacement},
                {"statements", FilingSubcategory.Statements},
                {"voluntary-arrangement", FilingSubcategory.VoluntaryArrangement},
                {"alter", FilingSubcategory.Alter},
                {"register", FilingSubcategory.Register},
                {"receiver", FilingSubcategory.Receiver},
                {"voluntary-arrangement-moratoria", FilingSubcategory.VoluntaryArrangementMoratoria},
                {"acquire", FilingSubcategory.Acquire},
                {"trustee", FilingSubcategory.Trustee},
                {"mortgage", FilingSubcategory.Mortgage},
                {"transfer", FilingSubcategory.Transfer},
                {"debenture", FilingSubcategory.Debenture},
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
                {"resolution", FilingCategory.Resolution},
                {"confirmation-statement", FilingCategory.ConfirmationStatement},
                {"persons-with-significant-control", FilingCategory.PersonsWithSignificantControl},
                {"restoration", FilingCategory.Restoration},
                {"return", FilingCategory.Return},
                {"other", FilingCategory.Other},
                {"reregistration", FilingCategory.ReRegistration},
                {"certificate", FilingCategory.Certificate},
            };

        public static readonly IReadOnlyDictionary<string, PersonWithSignificantControlKind> PossiblePersonWithSignificantControlKinds = new Dictionary
            <string, PersonWithSignificantControlKind>()
            {
                {"corporate-entity-person-with-significant-control", PersonWithSignificantControlKind.CorporateEntityPersonWithSignificantControl},
                {"individual-person-with-significant-control", PersonWithSignificantControlKind.IndividualPersonWithSignificantControl},
                {"super-secure-person-with-significant-control", PersonWithSignificantControlKind.IndividualPersonWithSignificantControl},
                {"legal-person-person-with-significant-control", PersonWithSignificantControlKind.IndividualPersonWithSignificantControl},
            };

        public static readonly IReadOnlyDictionary<string, AssetsCeasedReleased> PossibleAssetsCeasedReleased = new Dictionary<string, AssetsCeasedReleased>
        {
            {"property-ceased-to-belong", AssetsCeasedReleased.PropertyCeasedToBelong},
            {"part-property-release-and-ceased-to-belong", AssetsCeasedReleased.PartPropertyReleaseAndCeasedToBelong},
            {"part-property-released", AssetsCeasedReleased.PartPropertyReleased},
            {"part-property-ceased-to-belong", AssetsCeasedReleased.PartPropertyCeasedToBelong},
            {"whole-property-released", AssetsCeasedReleased.WholePropertyReleased},
            {"multiple-filings", AssetsCeasedReleased.MultipleFilings},
            {"whole-property-released-and-ceased-to-belong", AssetsCeasedReleased.WholePropertyReleasedAndCeasedToBelong}
        };

        public static readonly IReadOnlyDictionary<string, ParticularType> PossibleParticularTypes = new Dictionary<string, ParticularType>
        {
            {"short-particulars", ParticularType.ShortParticulars},
            {"charged-property-description", ParticularType.ChargedPropertyDescription},
            {"charged-property-or-undertaking-description", ParticularType.ChargedPropertyOrUndertakingDescription},
            {"brief-description", ParticularType.BriefDescription}
        };

        public static readonly IReadOnlyDictionary<string, ClassificationChargeType> PossibleClassificationChargeTypes = new Dictionary<string, ClassificationChargeType>
        {
            {"charge-description", ClassificationChargeType.ChargeDescription},
            {"nature-of-charge", ClassificationChargeType.NatureOfCharge}
        };

        public static readonly IReadOnlyDictionary<string, TermsOfAccountPublication> PossibleTermsOfAccountPublication = new Dictionary<string, TermsOfAccountPublication>
        {
            {"", TermsOfAccountPublication.None},
            {"accounts-publication-date-supplied-by-company", TermsOfAccountPublication.AccountsPublicationDateSuppliedByCompany},
            {"accounting-publication-date-does-not-need-to-be-supplied-by-company", TermsOfAccountPublication.AccountingPublicationDateDoesNotNeedToBeSuppliedByCompany},
            {"accounting-reference-date-allocated-by-companies-house", TermsOfAccountPublication.AccountingReferenceDateAllocatedByCompaniesHouse},
            
          };
        public static readonly IReadOnlyDictionary<string, ForeignAccountType> PossibleForeignAccountTypes = new Dictionary<string, ForeignAccountType>
        {
            {"", ForeignAccountType.None},
            {"accounting-requirements-of-originating-country-apply", ForeignAccountType.AccountingRequirementsOfOriginatingCountryApply},
            {"accounting-requirements-of-originating-country-do-not-apply", ForeignAccountType.AccountingRequirementsOfOriginatingCountryDoNotApply},
        };
        public static readonly IReadOnlyDictionary<string, SecuredDetailType> PossibleSecuredDetailTypes = new Dictionary<string, SecuredDetailType>
        {
            {"amount-secured", SecuredDetailType.AmountSecured},
            {"obligations-secured", SecuredDetailType.ObligationsSecured},
        };

        public static readonly IReadOnlyDictionary<string, ChargeStatus> PossibleChargeStatuses = new Dictionary<string, ChargeStatus>
        {
            {"outstanding", ChargeStatus.Outstanding},
            {"fully-satisfied", ChargeStatus.FullySatisfied},
            {"part-satisfied", ChargeStatus.PartSatisfied},
            {"satisfied", ChargeStatus.Satisfied}
        };
        
        public static readonly IReadOnlyDictionary<string, OfficeAddressCountry> PossibleRegisteredOfficeAddressCountry = new Dictionary<string, OfficeAddressCountry>
        {
            {"England", OfficeAddressCountry.England},
            {"Scotland", OfficeAddressCountry.Scotland},
            {"Wales", OfficeAddressCountry.Wales},
            {"Great Britain", OfficeAddressCountry.GreatBritain},
            {"Northern Ireland", OfficeAddressCountry.NorthernIreland},
            {"Not specified", OfficeAddressCountry.NotSpecified},
            {"United Kingdom", OfficeAddressCountry.UnitedKingdom}
        };
    }
}