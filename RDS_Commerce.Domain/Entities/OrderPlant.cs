namespace RDS_Commerce.Domain.Entities;
public sealed class OrderPlant
{
    public int OrderPlantId { get; set; }
    public int PlantId { get; set; }
    public int OrderId { get; set; }
    public int Quantity { get; set; }

    public Plant Plant { get; set; }
    public PurchaseOrder Order { get; set; }
}
