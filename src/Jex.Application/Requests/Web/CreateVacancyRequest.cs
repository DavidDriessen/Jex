namespace Jex.Application.Requests.Web;

public class AddVacancyToCompanyRequest
{
    [FastEndpoints.BindFrom("companyId")]
    public long CompanyId { get; set; }
    [FastEndpoints.FromBody]
    public Persistence.Abstraction.Models.Backoffice.Vacancy Vacancy { get; set; }
}