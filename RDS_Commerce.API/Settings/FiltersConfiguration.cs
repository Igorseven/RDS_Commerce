using RDS_Commerce.API.Filters;

namespace RDS_Commerce.API.Settings;

public static class FiltersConfiguration
{
    public static void AddFiltersHandler(this IServiceCollection services)
    {
        services.AddMvc(config => config.Filters.AddService<NotificationFilter>());
        services.AddMvc(config => config.Filters.AddService<UnitOfWorkFilter>());

        services.AddScoped<NotificationFilter>();
        services.AddScoped<UnitOfWorkFilter>();
    }
}
