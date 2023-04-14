using RDS_Commerce.ApplicationServices.Dtos.Request.PaymentHandlerRequest;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IPaymentHandlerCommandService : IDisposable
{
    Task<bool> CreatePaymentHandlerAsync(PaymentHandlerDtoForRegister paymentHandlerDtoForRegister);
    Task<bool> UpdatePaymentHandlerAsync(PaymentHandlerDtoForUpdate paymentHandlerDtoForUpdate);
}
