using Microsoft.Extensions.DependencyInjection;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Infrastructure.Repository;

namespace RDS_Commerce.IoC.DependencyInjectionSettings;
public static class RepositoryDependencyInjection
{
    public static void AddRepositoryDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IPlantRepository, PlantRepository>();
        services.AddScoped<IAccountIdentityRepository, AccountIdentityRepository>();
        services.AddScoped<IPlantImageRepository, PlantImageRepository>();
        services.AddScoped<IGenusRespository, GenusRespository>();
        services.AddScoped<IManagerRepository, ManagerRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IShippingAddressRepository, ShippingAddressRepository>();
        services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
        services.AddScoped<IOrderPlantRepository, OrderPlantRepository>();
    }
}
