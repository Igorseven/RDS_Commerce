using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RDS_Commerce.Infrastructure.ORM.Context;

namespace RDS_Commerce.IoC.DependencyInjectionSettings;
public static class DependencyInjectionHandler
{
    public static void AddDependencyInjectionHandler(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RdsContext>(config =>
        {
            config.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), sql => sql.CommandTimeout(180));
        });
            


        services.AddRepositoryDependencyInjection();
        services.AddOtherDependencyInjection();
        services.AddServiceDependencyInjection();
        services.AddPaginationDependencyInjection();
    }
}
