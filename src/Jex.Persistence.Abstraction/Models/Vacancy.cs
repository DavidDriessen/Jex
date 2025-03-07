using Jex.Persistence.Abstraction.Enums;

namespace Jex.Persistence.Abstraction.Models;

public class Vacancy
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public VacancyState State { get; set; }
    public Company Company { get; set; }
}