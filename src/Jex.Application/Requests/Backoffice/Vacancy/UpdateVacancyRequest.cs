namespace Jex.Application.Requests.Backoffice.Vacancy;

public class UpdateVacancyRequest
{
    [FastEndpoints.BindFrom("vacancyId")]
    public long VacancyId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}