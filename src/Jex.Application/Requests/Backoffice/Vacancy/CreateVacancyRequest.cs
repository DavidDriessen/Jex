﻿using Jex.Persistence.Abstraction.Enums;

namespace Jex.Application.Requests.Backoffice.Vacancy;

public class CreateVacancyRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public VacancyState State { get; set; }
}