namespace Jex.Application.Requests.Backoffice.Company;

public class UpdateCompanyRequest
{
    [FastEndpoints.BindFrom("companyId")]
    public long CompanyId { get; set; }

    [FastEndpoints.FromBody]
    public Persistence.Abstraction.Models.Backoffice.Company Company { get; set; }
}