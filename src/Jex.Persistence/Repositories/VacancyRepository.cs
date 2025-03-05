using Jex.Persistence.Abstraction.Models.Backoffice;
using Jex.Persistence.Abstraction.Repositories;
using Jex.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Jex.Persistence.Repositories;

public class VacancyRepository : IVacancyRepository
{
    private readonly DatabaseContext _databaseContext;

    public VacancyRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<Vacancy?> GetVacancy(long VacancyId)
    {
        return await _databaseContext.Vacancies.SingleOrDefaultAsync(c => c.Id == VacancyId);
    }

    public async Task<Vacancy> AddVacancy(Vacancy Vacancy)
    {
        _databaseContext.Vacancies.Add(Vacancy);
        await _databaseContext.SaveChangesAsync();
        return Vacancy;
    }

    public async Task UpdateVacancy(Vacancy Vacancy)
    {
        // ToDo: Implement correct way at updating 
        await _databaseContext.SaveChangesAsync();
    }

    public async Task DeleteVacancy(Vacancy Vacancy)
    {
        _databaseContext.Vacancies.Remove(Vacancy);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task<Vacancy> AddVacancyToCompany(Company company, Vacancy vacancy)
    {
        _databaseContext.Vacancies.Add(vacancy);
        var companyWithVacancies = await _databaseContext.CompaniesWithVacancies
            .SingleAsync(c => c.Id == company.Id);
        companyWithVacancies.Vacancies.Add(vacancy);
        await _databaseContext.SaveChangesAsync();

        return vacancy;
    }
}