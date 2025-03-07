using Jex.Persistence.Abstraction.Repositories;
using Jex.Persistence.Context;
using Jex.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Jex.Persistence.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<DatabaseContext>();

        serviceCollection.AddScoped<ICompanyRepository, CompanyRepository>();
        serviceCollection.AddScoped<IVacancyRepository, VacancyRepository>();
        
        return serviceCollection;
    }
}