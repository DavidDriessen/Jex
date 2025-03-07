using Jex.Application.Endpoints.Backoffice.Vacancy;
using Jex.Application.Requests.Web;
using Jex.Persistence.Abstraction.Models;
using Jex.Persistence.Abstraction.Repositories;

namespace Jex.Application.Endpoints.Web;

public class CreateVacancyForCompanyEndpoint :
    FastEndpoints.Endpoint<AddVacancyToCompanyRequest, Vacancy>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IVacancyRepository _vacancyRepository;

    public CreateVacancyForCompanyEndpoint(ICompanyRepository companyRepository, IVacancyRepository vacancyRepository)
    {
        _companyRepository = companyRepository;
        _vacancyRepository = vacancyRepository;
    }

    public override void Configure()
    {
        Post("/web/company/{companyId}/vacancy");

        AllowAnonymous();

        Description(x =>
        {
            x.WithTags("vacancy");
            FastEndpoints.RouteHandlerBuilderExtensions.ProducesProblemFE(x, 400);
            FastEndpoints.RouteHandlerBuilderExtensions.ProducesProblemFE(x, 404);
        });

        Summary(s =>
        {
            s.Summary = "Add vacancy to company";
            s.Responses[200] = "successful operation";
            s.Responses[400] = "Invalid vacancy supplied";
            s.Responses[404] = "Company not found";
        });
    }

    public override async Task HandleAsync(AddVacancyToCompanyRequest req, CancellationToken ct)
    {
        var company = await _companyRepository.GetCompany(req.CompanyId);
        if (company == null)
        {
            await SendErrorsAsync(404, cancellation: ct);
        }

        var vacancy = await _vacancyRepository.AddVacancyToCompany(company, req.Title, req.Description);

        await SendCreatedAtAsync<GetVacancyEndpoint>(vacancy.Id, vacancy, cancellation: ct);
    }
}