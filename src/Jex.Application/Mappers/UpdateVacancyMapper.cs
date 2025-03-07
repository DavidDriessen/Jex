using FastEndpoints;
using Jex.Application.Requests.Backoffice.Vacancy;
using Jex.Application.Responses;
using Jex.Persistence.Abstraction.Models;

namespace Jex.Application.Mappers;

public class UpdateVacancyMapper : Mapper<UpdateVacancyRequest, VacancyResponse, Vacancy>
{
    public override Vacancy ToEntity(UpdateVacancyRequest r) => new()
    {
        Id = r.VacancyId,
        Title = r.Title,
        Description = r.Description
    };

    public override VacancyResponse FromEntity(Vacancy e) => new()
    {
        Id = e.Id,
        Title = e.Title,
        Description = e.Description
    };
}