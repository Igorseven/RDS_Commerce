using RDS_Commerce.ApplicationServices.Dtos.Arguments;
using RDS_Commerce.ApplicationServices.Dtos.Response.BillingResponse;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IPaymentCommandService
{
    Task<bool> CardPaymentAsync(OrderForExecutePayment orderDtoForExecutePayment);
    Task<PixKeyPaymentResponse?> PaymentPixAsync(PixPayment pixPayment);
}
