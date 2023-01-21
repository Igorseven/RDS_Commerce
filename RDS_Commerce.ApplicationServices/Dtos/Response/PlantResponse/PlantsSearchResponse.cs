using RDS_Commerce.ApplicationServices.Dtos.Response.PlantImageResponse;
using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.ApplicationServices.Dtos.Response.PlantResponse;
public sealed class PlantsSearchResponse
{
    public int PlantId { get; set; }
    public string Name { get; set; }
    public string Specie { get; set; }
    public string? Description { get; set; }
    public int Amount { get; set; }
    public decimal Price { get; set; }
    public int VaseSize { get; set; }
    public EPlantType PlantType { get; set; }
    public PlantImageSearchResponse MainImage { get; set; }
}
