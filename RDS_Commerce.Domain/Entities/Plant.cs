using RDS_Commerce.Domain.Entities.BaseEntities;
using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.Domain.Entities;
public sealed class Plant : BaseEntity
{
    public string Name { get; set; }
    public string Specie { get; set; }
    public string? Description { get; set; }
    public int Amount { get; set; }
    public decimal Price { get; set; }
    public EProductType ProductType { get; set; }

    public List<PlantImage> Images { get; set; }

}
