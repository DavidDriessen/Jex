using Jex.Application.Requests.Backoffice.Company;
using Jex.Persistence.Abstraction.Repositories;

namespace Jex.Application.Endpoints.Backoffice.Company;

public class CreateCompanyEndpoint : FastEndpoints.Endpoint<CreateCompanyRequest, Persistence.Abstraction.Models.Backoffice.Company>
{
    private readonly ICompanyRepository _companyRepository;

    public CreateCompanyEndpoint(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }
    
    public override void Configure()
    {
        Post("/backoffice/company");

        AllowAnonymous();

        Description(x =>
        {
            x.WithTags("company");
            FastEndpoints.RouteHandlerBuilderExtensions.ProducesProblemFE(x, 400);
            FastEndpoints.RouteHandlerBuilderExtensions.ProducesProblemFE(x, 404);
        });

        Summary(s =>
        {
            s.Summary = "Create company";
            s.Responses[200] = "successful operation";
            s.Responses[400] = "Invalid company supplied";
        });
    }

    public override async Task HandleAsync(CreateCompanyRequest req, CancellationToken ct)
    {
        var company = await _companyRepository.AddCompany(req.Company);
            
        await SendCreatedAtAsync<GetCompanyEndpoint>(company.Id, company, cancellation: ct);
    }
}