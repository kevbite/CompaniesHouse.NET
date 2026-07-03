using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.Document;

namespace CompaniesHouse
{
    public interface ICompaniesHouseDocumentDownloadClient
    {
        Task<CompaniesHouseResponse<DocumentDownload>> DownloadDocumentAsync(string documentId, CancellationToken cancellationToken);
    }
}