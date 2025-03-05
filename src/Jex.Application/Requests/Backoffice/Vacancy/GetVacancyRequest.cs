namespace Jex.Application.Requests.Backoffice.Vacancy;

public class GetVacancyRequest
{
    [FastEndpoints.BindFrom("vacancyId")]
    public long VacancyId { get; set; }
}