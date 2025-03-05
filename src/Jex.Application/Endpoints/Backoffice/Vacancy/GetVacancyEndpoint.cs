using Jex.Application.Requests.Backoffice.Vacancy;
using Jex.Persistence.Abstraction.Repositories;

namespace Jex.Application.Endpoints.Backoffice.Vacancy;

public class GetVacancyEndpoint : FastEndpoints.Endpoint<GetVacancyRequest, Persistence.Abstraction.Models.Backoffice.Vacancy>
{
    private readonly IVacancyRepository _vacancyRepository;

    public GetVacancyEndpoint(IVacancyRepository vacancyRepository)
    {
        _vacancyRepository = vacancyRepository;
    }
    
    public override void Configure()
    {
        Get("/backoffice/vacancy/{vacancyId}");

        AllowAnonymous();

        Description(x =>
        {
            x.WithTags("vacancy");
            FastEndpoints.RouteHandlerBuilderExtensions.ProducesProblemFE(x, 400);
            FastEndpoints.RouteHandlerBuilderExtensions.ProducesProblemFE(x, 404);
        });

        Summary(s =>
        {
            s.Summary = "Find vacancy by ID";
            s.RequestParam(r => r.VacancyId, "ID of vacancy to return");
            s.Responses[200] = "successful operation";
            s.Responses[400] = "Invalid ID supplied";
            s.Responses[404] = "Vacancy not found";
        });
    }

    public override async Task HandleAsync(GetVacancyRequest req, CancellationToken ct)
    {
        var vacancy = await _vacancyRepository.GetVacancy(req.VacancyId);
        if (vacancy == null)
        {
            await SendErrorsAsync(404, ct);
        }
            
        await SendOkAsync(vacancy, cancellation: ct);
    }
}