using Jex.Persistence.Abstraction.Models.Backoffice;

namespace Jex.Persistence.Abstraction.Repositories;

public interface IVacancyRepository
{
    Task<Vacancy?> GetVacancy(long VacancyId);
    Task<Vacancy> AddVacancy(Vacancy Vacancy);
    Task UpdateVacancy(Vacancy Vacancy);
    Task DeleteVacancy(Vacancy Vacancy);
    Task<Vacancy> AddVacancyToCompany(Company company, Vacancy vacancy);
}