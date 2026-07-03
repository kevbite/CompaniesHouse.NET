using System.Threading;
using System.Threading.Tasks;
using CompaniesHouse.Response.PersonsWithSignificantControl;

namespace CompaniesHouse
{
    public interface ICompaniesHousePersonsWithSignificantControlDetailsClient
    {
        Task<CompaniesHouseResponse<PersonWithSignificantControl>> GetIndividualPersonWithSignificantControlAsync(string companyNumber, string notificationId, CancellationToken cancellationToken = default);

        Task<CompaniesHouseResponse<PersonWithSignificantControl>> GetIndividualBeneficialOwnerAsync(string companyNumber, string notificationId, CancellationToken cancellationToken = default);

        Task<CompaniesHouseResponse<PersonWithSignificantControl>> GetCorporateEntityPersonWithSignificantControlAsync(string companyNumber, string notificationId, CancellationToken cancellationToken = default);

        Task<CompaniesHouseResponse<PersonWithSignificantControl>> GetCorporateEntityBeneficialOwnerAsync(string companyNumber, string notificationId, CancellationToken cancellationToken = default);

        Task<CompaniesHouseResponse<PersonWithSignificantControl>> GetLegalPersonPersonWithSignificantControlAsync(string companyNumber, string notificationId, CancellationToken cancellationToken = default);

        Task<CompaniesHouseResponse<PersonWithSignificantControl>> GetLegalPersonBeneficialOwnerAsync(string companyNumber, string notificationId, CancellationToken cancellationToken = default);

        Task<CompaniesHouseResponse<PersonsWithSignificantControlStatements>> GetPersonsWithSignificantControlStatementsAsync(string companyNumber, int startIndex = 0, int pageSize = 25, bool? registerView = null, CancellationToken cancellationToken = default);

        Task<CompaniesHouseResponse<PersonWithSignificantControlStatement>> GetPersonsWithSignificantControlStatementAsync(string companyNumber, string statementId, CancellationToken cancellationToken = default);

        Task<CompaniesHouseResponse<SuperSecurePersonWithSignificantControl>> GetSuperSecurePersonWithSignificantControlAsync(string companyNumber, string superSecureId, CancellationToken cancellationToken = default);

        Task<CompaniesHouseResponse<SuperSecurePersonWithSignificantControl>> GetSuperSecureBeneficialOwnerAsync(string companyNumber, string superSecureId, CancellationToken cancellationToken = default);
    }
}
