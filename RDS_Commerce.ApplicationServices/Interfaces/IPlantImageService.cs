using RDS_Commerce.ApplicationServices.Dtos.Request.PlantRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.PlantImageResponse;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IPlantImageService : IDisposable
{
    Task<PlantImageSearchResponse?> FindByAsync(int plantImageId);
    Task<bool> UpdateMainImageAsync(PlantUpdateMainImageRequest updateRequest);
}
