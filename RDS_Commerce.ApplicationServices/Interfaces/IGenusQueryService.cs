using RDS_Commerce.ApplicationServices.Dtos.Response.GenusResponse;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IGenusQueryService
{
    Task<GenusDtoResponse?> FindByIdAsync(int genusId);
    Task<GenusDtoResponse?> FindByGenusNameAsync(string genusName);
}
