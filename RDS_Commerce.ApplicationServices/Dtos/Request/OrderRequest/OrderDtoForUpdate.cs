using RDS_Commerce.ApplicationServices.Dtos.Request.OrderPlantRequest;
using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.ApplicationServices.Dtos.Request.OrderRequest;
public sealed class OrderDtoForUpdate
{
    public int OrderId { get; set; }    
    public EOrderStatus OrderStatus { get; set; }
    public List<OrderPlantDtoForUpdatePlantInOrder> OrderPlantDtoForUpdatePlantInOrders { get; set; }
}
