using RDS_Commerce.ApplicationServices.Dtos.Request.OrderRequest;

namespace RDS_Commerce.ApplicationServices.Handlers.Factories.Payment;
public interface IPaymentFactory
{
    Task<bool> CreateNewPaymentAsync(OrderDtoForExecutePayment orderDtoForExecutePayment);
}
