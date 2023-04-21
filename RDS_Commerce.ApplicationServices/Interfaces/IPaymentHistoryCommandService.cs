using RDS_Commerce.ApplicationServices.Dtos.Request.PaymentHistoryRequest;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IPaymentHistoryCommandService : IDisposable
{
    Task CreatePaymentHistoryAsync(PaymentHistoryDtoForRegister paymentHistoryDtoForRegister);
}
