using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Core.Response.Document;

namespace CompaniesHouse.Core
{
    public interface ICompaniesHouseDocumentClient
    {
        Task<CompaniesHouseClientResponse<DocumentDownload>> DownloadDocumentAsync(string documentId, CancellationToken cancellationToken);
    }
}