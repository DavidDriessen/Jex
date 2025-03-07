using Jex.Application.Requests.Backoffice.Company;
using Jex.Application.Responses.Company;
using Jex.Persistence.Abstraction.Repositories;

namespace Jex.Application.Endpoints.Backoffice.Company;

public class CreateCompanyEndpoint : FastEndpoints.Endpoint<CreateCompanyRequest, CompanyResponse>
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
        var company = await _companyRepository.AddCompany(req.Name, req.Address);

        var response = new CompanyResponse
        {
            Id = company.Id,
            Name = company.Name,
            Address = company.Address
        };
        await SendCreatedAtAsync<GetCompanyEndpoint>(company.Id, response, cancellation: ct);
    }
}