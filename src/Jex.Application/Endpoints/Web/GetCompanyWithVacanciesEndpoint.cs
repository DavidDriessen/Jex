using Jex.Persistence.Abstraction.Models.web;
using Jex.Persistence.Abstraction.Repositories;

namespace Jex.Application.Endpoints.Web;

public class GetCompanyWithVacanciesEndpoint : FastEndpoints.EndpointWithoutRequest<List<CompanyWithVacancies>>
{
    private readonly ICompanyRepository _companyRepository;

    public GetCompanyWithVacanciesEndpoint(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public override void Configure()
    {
        Get("/Web/companies");

        AllowAnonymous();

        Description(x =>
        {
            x.WithTags("Web");
            FastEndpoints.RouteHandlerBuilderExtensions.ProducesProblemFE(x, 400);
            FastEndpoints.RouteHandlerBuilderExtensions.ProducesProblemFE(x, 404);
        });

        Summary(s =>
        {
            s.Summary = "Get companies with vacancies";
            s.Responses[200] = "successful operation";
        });
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var companyWithVacancies = await _companyRepository.GetCompaniesWithVacancies();

        await SendOkAsync(companyWithVacancies, cancellation: ct);
    }
}