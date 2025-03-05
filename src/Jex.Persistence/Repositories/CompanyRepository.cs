using Jex.Persistence.Abstraction.Models.Backoffice;
using Jex.Persistence.Abstraction.Models.web;
using Jex.Persistence.Abstraction.Repositories;
using Jex.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Jex.Persistence.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly DatabaseContext _databaseContext;

    public CompanyRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<Company?> GetCompany(long companyId)
    {
        return await _databaseContext.Companies.SingleOrDefaultAsync(c => c.Id == companyId);
    }

    public async Task<Company> AddCompany(Company company)
    {
        _databaseContext.Companies.Add(company);
        await _databaseContext.SaveChangesAsync();
        return company;
    }

    public async Task UpdateCompany(Company company)
    {
        // ToDo: Implement correct way at updating 
        await _databaseContext.SaveChangesAsync();
    }

    public async Task DeleteCompany(Company company)
    {
        _databaseContext.Companies.Remove(company);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task<List<CompanyWithVacancies>> GetCompaniesWithVacancies()
    {
        return await _databaseContext.CompaniesWithVacancies
            .Include(c => c.Vacancies)
            .ToListAsync();
    }
}