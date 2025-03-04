using Jex.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Jex.Persistence.DependencyInjection;

public static class HostExtensions
{
    public static IHost InitPersistence(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            using (var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>())
            {
                context.Database.Migrate();
            }
        }
        
        return host;
    }
}