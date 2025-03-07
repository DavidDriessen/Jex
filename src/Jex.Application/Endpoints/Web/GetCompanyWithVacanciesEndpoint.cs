using Jex.Application.Responses;
using Jex.Application.Responses.Company;
using Jex.Persistence.Abstraction.Repositories;

namespace Jex.Application.Endpoints.Web;

public class GetCompanyWithVacanciesEndpoint : FastEndpoints.EndpointWithoutRequest<List<CompanyWithVacanciesResponse>>
{
    private readonly ICompanyRepository _companyRepository;

    public GetCompanyWithVacanciesEndpoint(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public override void Configure()
    {
        Get("/web/companies");

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

        var response = companyWithVacancies.Select(c => new CompanyWithVacanciesResponse
        {
            Id = c.Id,
            Name = c.Name,
            Address = c.Address,
            Vacancies = c.Vacancies.Select(v => new CompanyVacancy
            {
                Title = v.Title,
                Description = v.Description
            }).ToList()
        }).ToList();

        await SendOkAsync(response, cancellation: ct);
    }
}