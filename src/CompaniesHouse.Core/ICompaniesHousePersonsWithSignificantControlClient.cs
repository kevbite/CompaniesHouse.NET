using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Core.Response.PersonsWithSignificantControl;

namespace CompaniesHouse.Core
{
    public interface ICompaniesHousePersonsWithSignificantControlClient
    {
        Task<CompaniesHouseClientResponse<PersonsWithSignificantControl>> GetPersonsWithSignificantControlAsync(string companyNumber, int startIndex, int pageSize, CancellationToken cancellationToken = default);
    }
}