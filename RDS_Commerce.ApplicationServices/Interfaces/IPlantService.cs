using RDS_Commerce.ApplicationServices.Dtos.Request.PlantRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.PlantResponse;
using RDS_Commerce.Business.Handler.PaginationSettings;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IPlantService
{
    Task<bool> SaveAsync(PlantSaveRequest saveRequest);
    Task<bool> UpdateAsync(PlantUpdateRequest updateRequest);
    Task<bool> InsertOtherImagesAsync(PlantUpdateImagesRequest updateRequest);
    Task<bool> UpdateMainImageAsync(PlantUpdateMainImageRequest updateRequest);
    Task<bool> DeleteAsync(int plantId);

    Task<PlantSearchResponse?> FindByAsync(int plantId);
    Task<PageList<PlantsSearchResponse>>? FindAllWithPaginationAsync(PageParams pageParams);
}
