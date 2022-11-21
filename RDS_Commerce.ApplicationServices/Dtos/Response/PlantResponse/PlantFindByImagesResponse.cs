using RDS_Commerce.ApplicationServices.Dtos.Response.PlantImageResponse;

namespace RDS_Commerce.ApplicationServices.Dtos.Response.PlantResponse;
public sealed class PlantFindByImagesResponse
{
    public int Id { get; set; }
    public List<PlantImageFindAllResponse> Images { get; set; }
}
