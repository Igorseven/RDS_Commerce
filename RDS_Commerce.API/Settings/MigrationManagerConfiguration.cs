using Microsoft.EntityFrameworkCore;
using RDS_Commerce.Infrastructure.ORM.Context;

namespace RDS_Commerce.API.Settings;

public static class MigrationManagerConfiguration
{
    public static WebApplication MigrateDatabase(this WebApplication webApp)
    {
        using (var scope = webApp.Services.CreateScope())
        {
            using (var appContext = scope.ServiceProvider.GetRequiredService<RdsContext>())
            {
                try
                {

                    appContext.Database.Migrate();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        return webApp;
    }
}
