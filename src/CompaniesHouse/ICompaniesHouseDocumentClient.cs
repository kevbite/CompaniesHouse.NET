namespace CompaniesHouse
{
    public interface ICompaniesHouseDocumentClient : 
        ICompaniesHouseDocumentMetadataClient,
        ICompaniesHouseDocumentDownloadClient
    {
        
    }
}