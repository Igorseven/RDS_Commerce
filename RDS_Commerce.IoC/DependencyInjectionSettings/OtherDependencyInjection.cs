using Microsoft.Extensions.DependencyInjection;
using RDS_Commerce.Business.Handler.NotificationSettings;
using RDS_Commerce.Business.Interfaces.OthersContracts;

namespace RDS_Commerce.IoC.DependencyInjectionSettings;
public static class OtherDependencyInjection
{
    public static void AddOtherDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<INotificationHandler, NotificationHandler>();
    }
}
