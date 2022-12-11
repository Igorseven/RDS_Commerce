namespace RDS_Commerce.API.Settings.EndPointSettings;

public static class EndPointsHandler
{
    public static WebApplication AddEndPointsHandler(this WebApplication app)
    {
        app.AddEndPointsPlant();

        return app;
    }
}
