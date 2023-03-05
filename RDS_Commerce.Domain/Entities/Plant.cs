using RDS_Commerce.Domain.Entities.Base;
using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.Domain.Entities;
public sealed class Plant : BaseEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public int Amount { get; set; }
    public decimal Price { get; set; }
    public int VaseSize { get; set; }
    public EPlantType PlantType { get; set; }

    public int? GenusId { get; set; }
    public Genus? Genus { get; set; }
    public List<Order> Orders { get; set; }
    public List<PlantImage> Images { get; set; }
}
