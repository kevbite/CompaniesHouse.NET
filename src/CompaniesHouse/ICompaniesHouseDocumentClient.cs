using System.IO;
using System.Threading.Tasks;

namespace CompaniesHouse
{
    public interface ICompaniesHouseDocumentClient
    {
        Task<CompaniesHouseClientResponse<Stream>> DownloadDocumentAsync(string documentId);
    }
}