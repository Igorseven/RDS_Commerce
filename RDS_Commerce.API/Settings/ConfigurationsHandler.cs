namespace RDS_Commerce.API.Settings;

public static class ConfigurationsHandler
{
    public static void AddConfigurations(this IServiceCollection services)
    {
        services.AddCorsConfiguration();
        services.AddControllersConfiguration();
        services.AddFiltersHandler();
    }
}
