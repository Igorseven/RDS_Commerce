using RDS_Commerce.ApplicationServices.Dtos.Request.OrderPlantRequest;
using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.ApplicationServices.Dtos.Request.PurchaseOrderRequest;
public sealed class PurchaseOrderDtoForUpdate
{
    public int OrderId { get; set; }    
    public EOrderStatus OrderStatus { get; set; }
    public List<OrderPlantDtoForUpdatePlantInOrder> OrderPlantDtoForUpdatePlantInOrders { get; set; }
}
