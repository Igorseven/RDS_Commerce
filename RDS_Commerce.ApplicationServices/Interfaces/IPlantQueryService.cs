using RDS_Commerce.ApplicationServices.Dtos.Response.PlantResponse;
using RDS_Commerce.Business.Handler.PaginationSettings;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IPlantQueryService
{
    Task<PlantDtoResponse?> FindByAsync(int plantId);
    Task<PageList<PlantsDtoResponse>>? FindAllWithPaginationAsync(PageParams pageParams);
}
