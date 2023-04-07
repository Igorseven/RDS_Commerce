using RDS_Commerce.ApplicationServices.Dtos.Arguments;

namespace RDS_Commerce.ApplicationServices.Handlers.Factories.Payment;
public interface IPaymentFactory
{
    Task<bool> CreateNewPaymentAsync(OrderForExecutePayment orderDtoForExecutePayment);
}
