namespace Jex.Application.Requests.Backoffice.Company;

public class DeleteCompanyRequest
{
    [FastEndpoints.BindFrom("companyId")]
    public long CompanyId { get; set; }
}