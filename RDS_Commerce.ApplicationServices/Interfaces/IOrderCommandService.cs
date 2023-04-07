using RDS_Commerce.ApplicationServices.Dtos.Arguments;
using RDS_Commerce.ApplicationServices.Dtos.Request.OrderRequest;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IOrderCommandService : IDisposable
{
    Task<bool> OrderUpdateAsync(OrderDtoForUpdate orderDtoForUpdate);
    Task<bool> FinalizeOrderAsync(OrderForExecutePayment orderForExecutePayment);
}
