using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.DisqualifiedOfficers;

namespace CompaniesHouse
{
    public interface ICompaniesHouseDisqualifiedOfficerDetailsClient
    {
        Task<CompaniesHouseResponse<NaturalDisqualification>> GetNaturalDisqualificationAsync(string officerId, CancellationToken cancellationToken = default);

        Task<CompaniesHouseResponse<CorporateDisqualification>> GetCorporateDisqualificationAsync(string officerId, CancellationToken cancellationToken = default);
    }
}
