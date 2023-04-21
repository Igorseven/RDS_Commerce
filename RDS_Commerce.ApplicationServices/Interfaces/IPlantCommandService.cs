using RDS_Commerce.ApplicationServices.Dtos.Request.PlantRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.PlantResponse;
using RDS_Commerce.Business.Handler.PaginationSettings;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IPlantCommandService : IDisposable
{
    Task<bool> CreatePlantAsync(PlantDtoForRegister saveRequest);
    Task<bool> UpdatePlantAsync(PlantDtoForUpdate updateRequest);
    Task<bool> InsertOtherImagesAsync(PlantDtoForUpdateImages updateRequest);
    Task<bool> DeleteAsync(int plantId);


}
