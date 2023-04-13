using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RDS_Commerce.Infrastructure.ORM.ContextSettings;

namespace RDS_Commerce.IoC.DependencyInjectionSettings;
public static class DependencyInjectionHandler
{
    public static void AddDependencyInjectionHandler(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<RdsApplicationDbContext>(options => options
                .UseSqlServer(configuration["ConnectionStrings:DefaultConnection"], sql => sql.CommandTimeout(180)));

        services.AddIdentityDependencyInjection(configuration);
        services.AddHttpClientDependencyInjection(configuration);
        services.AddRepositoryDependencyInjection();
        services.AddOtherDependencyInjection();
        services.AddServiceDependencyInjection();
        services.AddPaginationDependencyInjection();
        services.AddValidationDependencyInjection();
    }
}