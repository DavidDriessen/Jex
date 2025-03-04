namespace Jex.Application.Requests.Backoffice.Company;

public class CreateCompanyRequest
{
    [FastEndpoints.FromBody]
    public Persistence.Abstraction.Models.Backoffice.Company Company { get; set; }
}