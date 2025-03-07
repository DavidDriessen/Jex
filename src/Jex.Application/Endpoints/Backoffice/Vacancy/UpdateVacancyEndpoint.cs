using Jex.Application.Requests.Backoffice.Vacancy;
using Jex.Persistence.Abstraction.Repositories;

namespace Jex.Application.Endpoints.Backoffice.Vacancy;

public class UpdateVacancyEndpoint : FastEndpoints.Endpoint<UpdateVacancyRequest, Persistence.Abstraction.Models.Vacancy>
{
    private readonly IVacancyRepository _vacancyRepository;

    public UpdateVacancyEndpoint(IVacancyRepository vacancyRepository)
    {
        _vacancyRepository = vacancyRepository;
    }
    
    public override void Configure()
    {
        Put("/backoffice/vacancy/{vacancyId}");

        AllowAnonymous();

        Description(x =>
        {
            x.WithTags("vacancy");
            FastEndpoints.RouteHandlerBuilderExtensions.ProducesProblemFE(x, 400);
            FastEndpoints.RouteHandlerBuilderExtensions.ProducesProblemFE(x, 404);
        });

        Summary(s =>
        {
            s.Summary = "Update vacancy";
            s.RequestParam(r => r.VacancyId, "ID of vacancy to update");
            s.Responses[200] = "successful operation";
            s.Responses[400] = "Invalid vacancy supplied";
            s.Responses[404] = "Vacancy not found";
        });
    }

    public override async Task HandleAsync(UpdateVacancyRequest req, CancellationToken ct)
    {
        var vacancy = await _vacancyRepository.GetVacancy(req.VacancyId);

        vacancy.Title = req.Title;
        vacancy.Description = req.Description;
        
        await _vacancyRepository.UpdateVacancy(vacancy);
            
        await SendOkAsync(vacancy, cancellation: ct);
    }
}