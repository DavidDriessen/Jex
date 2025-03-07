namespace Jex.Application.Requests.Web;

public class AddVacancyToCompanyRequest
{
    [FastEndpoints.BindFrom("companyId")]
    public long CompanyId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}