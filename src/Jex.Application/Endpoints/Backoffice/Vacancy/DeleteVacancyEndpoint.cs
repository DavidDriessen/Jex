using Jex.Application.Requests.Backoffice.Vacancy;
using Jex.Persistence.Abstraction.Repositories;

namespace Jex.Application.Endpoints.Backoffice.Vacancy;

public class DeleteVacancyEndpoint : FastEndpoints.Endpoint<DeleteVacancyRequest>
{
    private readonly IVacancyRepository _vacancyRepository;

    public DeleteVacancyEndpoint(IVacancyRepository vacancyRepository)
    {
        _vacancyRepository = vacancyRepository;
    }
    
    public override void Configure()
    {
        Delete("/backoffice/vacancy/{vacancyId}");

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

    public override async Task HandleAsync(DeleteVacancyRequest req, CancellationToken ct)
    {
        var vacancy = await _vacancyRepository.GetVacancy(req.VacancyId);
        if (vacancy == null)
        {
            await SendErrorsAsync(404, ct);
        }
        await _vacancyRepository.DeleteVacancy(vacancy);
            
        await SendOkAsync(cancellation: ct);
    }
}