namespace RDS_Commerce.ApplicationServices.Dtos.Request.OrderPlantRequest;
public sealed class OrderPlantDtoForUpdatePlantInOrder
{
    public int PlantId { get; set; }
    public int OrderId { get; set; }
    public int Quantity { get; set; }
}
