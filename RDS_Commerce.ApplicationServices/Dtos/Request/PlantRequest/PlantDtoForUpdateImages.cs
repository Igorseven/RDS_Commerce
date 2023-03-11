using Microsoft.AspNetCore.Http;

namespace RDS_Commerce.ApplicationServices.Dtos.Request.PlantRequest;
public sealed class PlantDtoForUpdateImages
{
    public int PlantId { get; set; }
    public List<IFormFile> FormFileImages { get; set; }
}
