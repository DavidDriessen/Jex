using Jex.Persistence.Abstraction.Enums;

namespace Jex.Application.Responses;

public class VacancyResponse
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public VacancyState State { get; set; }
}