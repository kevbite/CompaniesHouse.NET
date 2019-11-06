using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.PersonsWithSignificantControl;

namespace CompaniesHouse
{
    public interface ICompaniesHousePersonsWithSignificantControlClient
    {
        Task<CompaniesHouseClientResponse<PersonsWithSignificantControl>> GetPersonsWithSignificantControlAsync(string companyNumber, int startIndex, int pageSize, CancellationToken cancellationToken = default);
    }
}