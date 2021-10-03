using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.Charges;

namespace CompaniesHouse
{
    public interface ICompaniesHouseChargesClient
    {
        Task<CompaniesHouseClientResponse<Charges>> GetChargesListAsync(string companyNumber,int startIndex, int pageSize, CancellationToken cancellationToken);
        Task<CompaniesHouseClientResponse<Charge>> GetChargeByIdAsync(string companyNumber, string chargeId, CancellationToken cancellationToken);
    }
}