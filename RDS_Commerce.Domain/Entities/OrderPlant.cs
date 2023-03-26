namespace RDS_Commerce.Domain.Entities;
public sealed class OrderPlant
{
    public int PlantId { get; set; }
    public int OrderId { get; set; }
    public int Quantity { get; set; }

    public Plant Plant { get; set; }
    public Order Order { get; set; }
}
