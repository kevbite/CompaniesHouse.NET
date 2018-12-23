using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.Appointments;

namespace CompaniesHouse
{
    internal interface ICompaniesHouseAppointmentsClient
    {
        Task<CompaniesHouseClientResponse<Appointments>> GetAppointmentsAsync(string officerId, int startIndex, int pageSize, CancellationToken cancellationToken);
    }
}