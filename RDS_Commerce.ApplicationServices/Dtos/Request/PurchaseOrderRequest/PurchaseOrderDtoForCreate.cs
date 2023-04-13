using RDS_Commerce.ApplicationServices.Dtos.Request.OrderPlantRequest;
using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.ApplicationServices.Dtos.Request.PurchaseOrderRequest;
public sealed class PurchaseOrderDtoForCreate
{
    public EOrderStatus OrderStatus { get; set; }
    public Guid ClientId { get; set; }
    public List<OrderPlantDtoForAddPlantInOrder> OrderPlantDtoForAddPlantInOrders { get; set; }
}
