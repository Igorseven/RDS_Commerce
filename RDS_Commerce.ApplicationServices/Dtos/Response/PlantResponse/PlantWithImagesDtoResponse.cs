using RDS_Commerce.ApplicationServices.Dtos.Response.PlantImageResponse;

namespace RDS_Commerce.ApplicationServices.Dtos.Response.PlantResponse;
public sealed class PlantWithImagesDtoResponse
{
    public int Id { get; set; }
    public List<PlantImageDtoResponse> Images { get; set; }
}
