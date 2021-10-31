using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.Officers;

namespace CompaniesHouse
{
    internal interface ICompaniesHouseOfficerByAppointmentClient
    {
        Task<CompaniesHouseClientResponse<Officer>> GetOfficerByAppointmentIdAsync(string companyNumber, string appointmentId, CancellationToken cancellationToken);
    }
}