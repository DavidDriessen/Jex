namespace Jex.Persistence.Abstraction.Models;

public class Company
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public List<Vacancy> Vacancies { get; set; } = [];
}