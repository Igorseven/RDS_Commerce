namespace RDS_Commerce.ApplicationServices.Dtos.Request.OrderPlantRequest;
public sealed class OrderPlantDtoForAddPlantInOrder
{
    public int PlantId { get; set; }
    public int Quantity { get; set; }
    public Guid ClientId { get; set; }
}
