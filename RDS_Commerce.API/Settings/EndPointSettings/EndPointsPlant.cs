using RDS_Commerce.API.EndPoints;
using RDS_Commerce.Domain.Entities;

namespace RDS_Commerce.API.Settings.EndPointSettings;

public static class EndPointsPlant
{
    public static WebApplication AddEndPointsPlant(this WebApplication app)
    {
        app.MapMethods(PlantPost.Template, PlantPost.Methods, PlantPost.Handler);


        return app;
    }
}
