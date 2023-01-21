using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.ApplicationServices.Dtos.Request.PlantRequest;
public sealed class PlantUpdateRequest
{
    public int PlantId { get; set; }
    public string Name { get; set; }
    public string Specie { get; set; }
    public string? Description { get; set; }
    public int Amount { get; set; }
    public decimal Price { get; set; }
    public int VaseSize { get; set; }
    public EPlantType ProductType { get; set; }
}
