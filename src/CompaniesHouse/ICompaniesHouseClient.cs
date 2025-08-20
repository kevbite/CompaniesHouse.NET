namespace CompaniesHouse
{
    public interface ICompaniesHouseClient :
        ICompaniesHouseSearchCompanyClient,
        ICompaniesHouseSearchCompanyAdvancedClient,
        ICompaniesHouseSearchOfficerClient,
        ICompaniesHouseSearchDisqualifiedOfficerClient,
        ICompaniesHouseSearchAllClient,
        ICompaniesHouseCompanyProfileClient,
        ICompaniesHouseCompanyFilingHistoryClient,
        ICompaniesHouseOfficersClient,
        ICompaniesHouseCompanyInsolvencyInformationClient,
        ICompaniesHouseAppointmentsClient,
        ICompaniesHousePersonsWithSignificantControlClient,
        ICompaniesHouseChargesClient
    {

    }
}