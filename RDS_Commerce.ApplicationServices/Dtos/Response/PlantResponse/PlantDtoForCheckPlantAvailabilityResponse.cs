using RDS_Commerce.ApplicationServices.Dtos.Response.GenusResponse;
using RDS_Commerce.ApplicationServices.Dtos.Response.PlantImageResponse;

namespace RDS_Commerce.ApplicationServices.Dtos.Response.PlantResponse;
public sealed class PlantDtoForCheckPlantAvailabilityResponse
{
    public int PlantId { get; set; }
    public string Name { get; set; }
    public string Specie { get; set; }
    public int Quantity { get; set; }
    public int OrderQuantity { get; set; }
    public decimal Price { get; set; }
    public int VaseSize { get; set; }
    public GenusDtoResponse Genus { get; set; }
    public PlantImageDtoResponse MainImage { get; set; }
}
