using RDS_Commerce.ApplicationServices.Dtos.Request.PlantRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.PlantImageResponse;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IPlantImageCommandService : IDisposable
{
    Task<bool> UpdateMainImageAsync(PlantDtoForUpdateMainImage updateRequest);
}
