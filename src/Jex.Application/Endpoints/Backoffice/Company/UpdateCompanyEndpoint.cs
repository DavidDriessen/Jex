using Jex.Application.Requests.Backoffice.Company;
using Jex.Persistence.Abstraction.Repositories;

namespace Jex.Application.Endpoints.Backoffice.Company;

public class UpdateCompanyEndpoint : FastEndpoints.Endpoint<UpdateCompanyRequest, Persistence.Abstraction.Models.Backoffice.Company>
{
    private readonly ICompanyRepository _companyRepository;

    public UpdateCompanyEndpoint(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }
    
    public override void Configure()
    {
        Post("/backoffice/company/{companyId}");

        AllowAnonymous();

        Description(x =>
        {
            x.WithTags("company");
            FastEndpoints.RouteHandlerBuilderExtensions.ProducesProblemFE(x, 400);
            FastEndpoints.RouteHandlerBuilderExtensions.ProducesProblemFE(x, 404);
        });

        Summary(s =>
        {
            s.Summary = "Update company";
            s.RequestParam(r => r.CompanyId, "ID of company to update");
            s.Responses[200] = "successful operation";
            s.Responses[400] = "Invalid company supplied";
            s.Responses[404] = "Company not found";
        });
    }

    public override async Task HandleAsync(UpdateCompanyRequest req, CancellationToken ct)
    {
        var company = await _companyRepository.GetCompany(req.CompanyId);

        company.Name = req.Company.Name;
        company.Address = req.Company.Address;
        
        await _companyRepository.UpdateCompany(company);
            
        await SendOkAsync(company, cancellation: ct);
    }
}