namespace Jex.Application.Requests.Backoffice.Vacancy;

public class DeleteVacancyRequest
{
    [FastEndpoints.BindFrom("vacancyId")]
    public long VacancyId { get; set; }
}