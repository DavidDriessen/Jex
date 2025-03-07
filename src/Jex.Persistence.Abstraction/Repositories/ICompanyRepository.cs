using Jex.Persistence.Abstraction.Models;

namespace Jex.Persistence.Abstraction.Repositories;

public interface ICompanyRepository
{
    Task<Company?> GetCompany(long companyId);
    Task<Company> AddCompany(string companyName, string companyAddress);
    Task UpdateCompany(Company company);
    Task DeleteCompany(Company company);
    Task<List<Company>> GetCompaniesWithVacancies();
}