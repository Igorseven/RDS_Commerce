using Microsoft.Extensions.DependencyInjection;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.ApplicationServices.Services.AccountIdentityServices;
using RDS_Commerce.ApplicationServices.Services.AuthenticationTokenServices;
using RDS_Commerce.ApplicationServices.Services.ClientServices;
using RDS_Commerce.ApplicationServices.Services.GenusServices;
using RDS_Commerce.ApplicationServices.Services.ManagerServices;
using RDS_Commerce.ApplicationServices.Services.PlantImageServices;
using RDS_Commerce.ApplicationServices.Services.PlantServices;
using RDS_Commerce.ApplicationServices.Services.ShippingAddressServices;

namespace RDS_Commerce.IoC.DependencyInjectionSettings;
public static class ServiceDependencyInjection
{
    public static void AddServiceDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationTokenService, AuthenticationTokenService>();
        services.AddScoped<IAccountIdentityService, AccountIdentityService>();

        services.AddScoped<IPlantCommandService, PlantCommandService>();
        services.AddScoped<IPlantQueryService, PlantQueryService>();

        services.AddScoped<IPlantImageCommandService, PlantImageCommandService>();
        services.AddScoped<IPlantImageQueryService, PlantImageQueryService>();

        services.AddScoped<IGenusCommandService, GenusCommandService>();
        services.AddScoped<IGenusQueryService, GenusQueryService>();

        services.AddScoped<IManagerCommandService, ManagerCommandService>();
        services.AddScoped<IManagerQueryService, ManagerQueryService>();

        services.AddScoped<IClientCommandService, ClientCommandService>();
        services.AddScoped<IClientQueryService, ClientQueryService>();

        services.AddScoped<IShippingAddressCommandService, ShippingAddressCommandService>();
        services.AddScoped<IShippingAddressQueryService, ShippingAddressQueryService>();

    }
}
