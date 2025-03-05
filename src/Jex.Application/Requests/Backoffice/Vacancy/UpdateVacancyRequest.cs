namespace Jex.Application.Requests.Backoffice.Vacancy;

public class UpdateVacancyRequest
{
    [FastEndpoints.BindFrom("vacancyId")]
    public long VacancyId { get; set; }

    [FastEndpoints.FromBody]
    public Persistence.Abstraction.Models.Backoffice.Vacancy Vacancy { get; set; }
}