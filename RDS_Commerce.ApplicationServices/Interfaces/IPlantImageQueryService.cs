using RDS_Commerce.ApplicationServices.Dtos.Response.PlantImageResponse;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IPlantImageQueryService
{
    Task<PlantImageDtoResponse?> FindByAsync(int plantImageId);
}
