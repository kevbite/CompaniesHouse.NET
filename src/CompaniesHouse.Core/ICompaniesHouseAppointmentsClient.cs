using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.Appointments;

namespace CompaniesHouse
{
    public interface ICompaniesHouseAppointmentsClient
    {
        Task<CompaniesHouseClientResponse<Appointments>> GetAppointmentsAsync(string officerId, int startIndex = 0, int pageSize = 25, CancellationToken cancellationToken = default(CancellationToken));
    }
}