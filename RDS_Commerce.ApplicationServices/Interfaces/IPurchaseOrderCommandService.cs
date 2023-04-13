using RDS_Commerce.ApplicationServices.Dtos.Arguments;
using RDS_Commerce.ApplicationServices.Dtos.Request.OrderPlantRequest;
using RDS_Commerce.ApplicationServices.Dtos.Request.PurchaseOrderRequest;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IPurchaseOrderCommandService : IDisposable
{
    Task<bool> OrderUpdateAsync(PurchaseOrderDtoForUpdate orderDtoForUpdate);
    Task<bool> AddPlantToOrderAsync(OrderPlantDtoForAddPlantInOrder orderPlantDtoForAddPlantInOrder);
    Task<bool> FinalizeOrderAsync(OrderForExecutePayment orderForExecutePayment);
}
