using Jex.Persistence.Abstraction.Enums;
using Jex.Persistence.Abstraction.Models;
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

    public async Task<Vacancy> AddVacancy(string title, string description, VacancyState state)
    {
        var vacancy = new Vacancy
        {
            Title = title,
            Description = description,
            State = state
        };
        _databaseContext.Vacancies.Add(vacancy);
        await _databaseContext.SaveChangesAsync();
        return vacancy;
    }

    public async Task UpdateVacancy(Vacancy Vacancy)
    {
        _databaseContext.Entry(Vacancy).State = EntityState.Modified;
        await _databaseContext.SaveChangesAsync();
    }

    public async Task DeleteVacancy(Vacancy Vacancy)
    {
        _databaseContext.Vacancies.Remove(Vacancy);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task<Vacancy> AddVacancyToCompany(Company company, string title, string description)
    {
        var vacancy = new Vacancy
        {
            Title = title,
            Description = description
        };
        _databaseContext.Vacancies.Add(vacancy);
        var companyWithVacancies = await _databaseContext.Companies
            .SingleAsync(c => c.Id == company.Id);
        companyWithVacancies.Vacancies.Add(vacancy);
        await _databaseContext.SaveChangesAsync();

        return vacancy;
    }
}