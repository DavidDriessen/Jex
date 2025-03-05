using Jex.Application.Requests.Backoffice.Vacancy;
using Jex.Persistence.Abstraction.Repositories;

namespace Jex.Application.Endpoints.Backoffice.Vacancy;

public class CreateVacancyEndpoint : FastEndpoints.Endpoint<CreateVacancyRequest,
    Persistence.Abstraction.Models.Backoffice.Vacancy>
{
    private readonly IVacancyRepository _vacancyRepository;

    public CreateVacancyEndpoint(IVacancyRepository vacancyRepository)
    {
        _vacancyRepository = vacancyRepository;
    }

    public override void Configure()
    {
        Post("/backoffice/vacancy");

        AllowAnonymous();

        Description(x =>
        {
            x.WithTags("vacancy");
            FastEndpoints.RouteHandlerBuilderExtensions.ProducesProblemFE(x, 400);
            FastEndpoints.RouteHandlerBuilderExtensions.ProducesProblemFE(x, 404);
        });

        Summary(s =>
        {
            s.Summary = "Create vacancy";
            s.Responses[200] = "successful operation";
            s.Responses[400] = "Invalid vacancy supplied";
        });
    }

    public override async Task HandleAsync(CreateVacancyRequest req, CancellationToken ct)
    {
        if (req.Vacancy.Id != 0)
        {
            await SendErrorsAsync(cancellation: ct);
        }

        var vacancy = await _vacancyRepository.AddVacancy(req.Vacancy);

        await SendCreatedAtAsync<GetVacancyEndpoint>(vacancy.Id, vacancy, cancellation: ct);
    }
}