using Microsoft.Extensions.DependencyInjection;
using RDS_Commerce.Business.Handler.ValidationSettings.EntitiesValidation;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Domain.Entities;

namespace RDS_Commerce.IoC.DependencyInjectionSettings;
public static class ValidationDependencyInjection
{
    public static void AddValidationDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IValidate<Plant>, PlantValidation>();
        services.AddScoped<IValidate<PlantImage>, PlantImageValidation>();
        services.AddScoped<IValidate<Genus>, GenusValidation>();
    }
}
