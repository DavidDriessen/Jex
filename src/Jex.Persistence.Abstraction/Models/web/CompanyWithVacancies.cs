using Jex.Persistence.Abstraction.Models.Backoffice;

namespace Jex.Persistence.Abstraction.Models.web;

public class CompanyWithVacancies : Company
{
    public List<Vacancy> Vacancies { get; set; } = [];
}