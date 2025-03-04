using Jex.Persistence.Abstraction.Models.Backoffice;

namespace Jex.Persistence.Abstraction.Repositories;

public interface ICompanyRepository
{
    Task<Company?> GetCompany(long companyId);
    Task<Company> AddCompany(Company company);
    Task UpdateCompany(Company company);
    Task DeleteCompany(Company company);
}