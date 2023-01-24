using Microsoft.Extensions.DependencyInjection;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Infrastructure.Repository;

namespace RDS_Commerce.IoC.DependencyInjectionSettings;
public static class RepositoryDependencyInjection
{
    public static void AddRepositoryDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IPlantRepository, PlantRepository>();
        services.AddScoped<IPlantImageRepository, PlantImageRepository>();
        services.AddScoped<IGenusRespository, GenusRespository>();
    }
}
