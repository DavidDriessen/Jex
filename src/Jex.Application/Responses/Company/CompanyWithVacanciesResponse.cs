namespace Jex.Application.Responses.Company;

public class CompanyWithVacanciesResponse
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public List<CompanyVacancy> Vacancies { get; set; }
}