using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.Document;

namespace CompaniesHouse
{
    public interface ICompaniesHouseDocumentClient
    {
        Task<CompaniesHouseClientResponse<DocumentDownload>> DownloadDocumentAsync(string documentId, CancellationToken cancellationToken);
    }
}