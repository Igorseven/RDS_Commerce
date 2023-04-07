using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RDS_Commerce.IoC.DependencyInjectionSettings;
public static class HttpClientDependencyInjection
{
    public static void AddHttpClientDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient("AsaasHttpClient", h => h.BaseAddress = new(configuration["AsasConfig:URL"]!));
    }
}
