using Microsoft.Extensions.DependencyInjection;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.ApplicationServices.Services;

namespace RDS_Commerce.IoC.DependencyInjectionSettings;
public static class ServiceDependencyInjection
{
    public static void AddServiceDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IPlantService, PlantService>();
        services.AddScoped<IPlantImageService, PlantImageService>();
        services.AddScoped<IGenusService, GenusService>();
        services.AddScoped<IAuthenticationTokenService, AuthenticationTokenService>();
        services.AddScoped<IAccountIdentityService, AccountIdentityService>();
        services.AddScoped<IManagerService, ManagerService>();
        services.AddScoped<IClientService, ClientService>();

    }
}
