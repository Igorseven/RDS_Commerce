using Microsoft.AspNetCore.Http;

namespace RDS_Commerce.ApplicationServices.Dtos.Request.PlantRequest;
public sealed class PlantUpdateImagesRequest
{
    public int PlantId { get; set; }
    public List<IFormFile> FormFileImages { get; set; }
}
