namespace Jex.Application.Requests.Backoffice.Company;

public class GetCompanyRequest
{
    [FastEndpoints.BindFrom("companyId")]
    public long CompanyId { get; set; }
}