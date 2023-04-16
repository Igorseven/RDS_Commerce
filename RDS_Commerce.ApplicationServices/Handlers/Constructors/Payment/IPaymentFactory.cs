using RDS_Commerce.ApplicationServices.Dtos.Arguments;
using RDS_Commerce.ApplicationServices.Dtos.Response.BillingResponse;

namespace RDS_Commerce.ApplicationServices.Handlers.Factories.Payment;
public interface IPaymentFactory
{
    Task<bool> CreateNewPaymentAsync(OrderForExecutePayment orderDtoForExecutePayment);
    Task<PixKeyPaymentResponse?> PaymentPixAsync(PixPayment pixPayment);
}
