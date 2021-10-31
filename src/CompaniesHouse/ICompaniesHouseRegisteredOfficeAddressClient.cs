using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.RegisteredOfficeAddress;

namespace CompaniesHouse
{
    internal interface ICompaniesHouseRegisteredOfficeAddressClient
    {
        Task<CompaniesHouseClientResponse<OfficeAddress>> GetRegisteredOfficeAddress(string companyNumber, CancellationToken cancellationToken);
    }
}