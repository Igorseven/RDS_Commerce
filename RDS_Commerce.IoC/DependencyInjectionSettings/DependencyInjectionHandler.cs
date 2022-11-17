using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RDS_Commerce.IoC.DependencyInjectionSettings;
public static class DependencyInjectionHandler
{
    public static void AddDependencyInjectionHandler(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepositoryDependencyInjection();
        services.AddOtherDependencyInjection();
        services.AddServiceDependencyInjection();
        services.AddPaginationDependencyInjection();
    }
}
