using Jex.Application.Requests.Backoffice.Company;
using Jex.Persistence.Abstraction.Repositories;

namespace Jex.Application.Endpoints.Backoffice.Company;

public class DeleteCompanyEndpoint : FastEndpoints.Endpoint<DeleteCompanyRequest>
{
    private readonly ICompanyRepository _companyRepository;

    public DeleteCompanyEndpoint(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }
    
    public override void Configure()
    {
        Delete("/backoffice/company/{companyId}");

        AllowAnonymous();

        Description(x =>
        {
            x.WithTags("company");
            FastEndpoints.RouteHandlerBuilderExtensions.ProducesProblemFE(x, 400);
            FastEndpoints.RouteHandlerBuilderExtensions.ProducesProblemFE(x, 404);
        });

        Summary(s =>
        {
            s.Summary = "Find company by ID";
            s.RequestParam(r => r.CompanyId, "ID of company to return");
            s.Responses[200] = "successful operation";
            s.Responses[400] = "Invalid ID supplied";
            s.Responses[404] = "Company not found";
        });
    }

    public override async Task HandleAsync(DeleteCompanyRequest req, CancellationToken ct)
    {
        var company = await _companyRepository.GetCompany(req.CompanyId);
        if (company == null)
        {
            await SendErrorsAsync(404, ct);
        }
        await _companyRepository.DeleteCompany(company);
            
        await SendOkAsync(cancellation: ct);
    }
}