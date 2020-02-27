using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Core.Response.Document;

namespace CompaniesHouse.Core
{
    public interface ICompaniesHouseDocumentMetadataClient
    {
        Task<CompaniesHouseClientResponse<DocumentMetadata>> GetDocumentMetadataAsync(string documentId, CancellationToken caneCancellationToken = default);
    }
}