using Jex.Application.Requests.Backoffice.Company;
using Jex.Persistence.Abstraction.Repositories;

namespace Jex.Application.Endpoints.Backoffice.Company;

public class GetCompanyEndpoint : FastEndpoints.Endpoint<GetCompanyRequest, Persistence.Abstraction.Models.Backoffice.Company>
{
    private readonly ICompanyRepository _companyRepository;

    public GetCompanyEndpoint(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }
    
    public override void Configure()
    {
        Get("/backoffice/company/{companyId}");

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

    public override async Task HandleAsync(GetCompanyRequest req, CancellationToken ct)
    {
        var company = await _companyRepository.GetCompany(req.CompanyId);
        if (company == null)
        {
            await SendErrorsAsync(404, ct);
        }
            
        await SendOkAsync(company, cancellation: ct);
    }
}