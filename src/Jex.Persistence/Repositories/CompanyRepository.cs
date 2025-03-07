using Jex.Persistence.Abstraction.Enums;
using Jex.Persistence.Abstraction.Models;
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

    public async Task<Company> AddCompany(string companyName, string companyAddress)
    {
        var company = new Company
        {
            Name = companyName,
            Address = companyAddress
        };
        _databaseContext.Companies.Add(company);
        await _databaseContext.SaveChangesAsync();
        return company;
    }

    public async Task UpdateCompany(Company company)
    {
        _databaseContext.Entry(company).State = EntityState.Modified;
        await _databaseContext.SaveChangesAsync();
    }

    public async Task DeleteCompany(Company company)
    {
        _databaseContext.Companies.Remove(company);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task<List<Company>> GetCompaniesWithVacancies()
    {
        return await _databaseContext.Companies
            .Include(c => c.Vacancies)
            .Where(c => c.Vacancies.Any(v => v.State == VacancyState.Active))
            .ToListAsync();
    }
}