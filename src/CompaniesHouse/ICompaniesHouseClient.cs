namespace CompaniesHouse
{
    public interface ICompaniesHouseClient :
        ICompaniesHouseSearchCompanyClient,
        ICompaniesHouseSearchOfficerClient,
        ICompaniesHouseSearchDisqualifiedOfficerClient,
        ICompaniesHouseSearchAllClient,
        ICompaniesHouseSearchCompaniesAlphabeticallyClient,
        ICompaniesHouseSearchDissolvedCompaniesClient,
        ICompaniesHouseAdvancedCompanySearchClient,
        ICompaniesHouseCompanyProfileClient,
        ICompaniesHouseCompanyFilingHistoryClient,
        ICompaniesHouseOfficersClient,
        ICompaniesHouseCompanyInsolvencyInformationClient,
        ICompaniesHouseAppointmentsClient,
        ICompaniesHousePersonsWithSignificantControlClient,
        ICompaniesHouseChargesClient,
        ICompaniesHouseRegisteredOfficeAddressClient,
        ICompaniesHouseRegistersClient
    {

    }
}