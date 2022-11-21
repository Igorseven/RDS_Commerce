using RDS_Commerce.ApplicationServices.Dtos.Request.PlantRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.PlantResponse;
using RDS_Commerce.Business.Handler.PaginationSettings;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IPlantService
{
    Task<bool> SaveAsync(PlantSaveRequest saveRequest);
    Task<bool> UpdateAsync(PlantUpdateRequest updateRequest);
    Task<bool> DeleteAsync(int plantId);

    Task<PlantFindByResponse> FindByAsync(int plantId);
    Task<List<PlantFindWithPaginationResponse>> FindAllAsync(PageParams pageParams);
}
