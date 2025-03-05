namespace Jex.Application.Requests.Backoffice.Vacancy;

public class CreateVacancyRequest
{
    [FastEndpoints.FromBody]
    public Persistence.Abstraction.Models.Backoffice.Vacancy Vacancy { get; set; }
}