namespace Jex.Application.Requests.Backoffice.Company;

public class UpdateCompanyRequest
{
    [FastEndpoints.BindFrom("companyId")]
    public long CompanyId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}