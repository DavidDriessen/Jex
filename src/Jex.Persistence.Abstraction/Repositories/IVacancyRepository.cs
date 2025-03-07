using Jex.Persistence.Abstraction.Enums;
using Jex.Persistence.Abstraction.Models;

namespace Jex.Persistence.Abstraction.Repositories;

public interface IVacancyRepository
{
    Task<Vacancy?> GetVacancy(long VacancyId);
    Task<Vacancy> AddVacancy(string title, string description, VacancyState state);
    Task UpdateVacancy(Vacancy Vacancy);
    Task DeleteVacancy(Vacancy Vacancy);
    Task<Vacancy> AddVacancyToCompany(Company company, string title, string description);
}