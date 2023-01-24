using RDS_Commerce.ApplicationServices.Dtos.Request.GenusRequest;
using RDS_Commerce.ApplicationServices.Dtos.Response.GenusResponse;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IGenusService : IDisposable
{
    Task<bool> CreateNewGenusAsync(GenusSaveRequest saveRequest);
    Task<bool> UpdateGenusAsync(GenusUpdateRequest updateRequest);
    Task<bool> DeleteGeneusAsync(int genusId);
    Task<GenusSearchResponse> FindByAsync(int genusId);
    Task<GenusSearchResponse> FindByGenusNameAsync(string genusName);
}
