using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.RegisteredOfficeAddress;

namespace CompaniesHouse
{
    public interface ICompaniesHouseRegisteredOfficeAddressClient
    {
        Task<CompaniesHouseResponse<OfficeAddress>> GetRegisteredOfficeAddress(string companyNumber, CancellationToken cancellationToken = default);
    }
}