using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.Registers;

namespace CompaniesHouse
{
    public interface ICompaniesHouseRegistersClient
    {
        Task<CompaniesHouseResponse<CompanyRegisters>> GetCompanyRegistersAsync(string companyNumber, CancellationToken cancellationToken = default);
    }
}
