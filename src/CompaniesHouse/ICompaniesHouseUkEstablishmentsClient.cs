using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.UkEstablishments;

namespace CompaniesHouse
{
    public interface ICompaniesHouseUkEstablishmentsClient
    {
        Task<CompaniesHouseResponse<CompanyUkEstablishments>> GetCompanyUkEstablishmentsAsync(string companyNumber, CancellationToken cancellationToken = default);
    }
}
