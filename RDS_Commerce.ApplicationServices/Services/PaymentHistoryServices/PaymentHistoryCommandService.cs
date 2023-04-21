using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Dtos.Request.PaymentHistoryRequest;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;

namespace RDS_Commerce.ApplicationServices.Services.PaymentHistoryServices;
public sealed class PaymentHistoryCommandService : IPaymentHistoryCommandService
{
    private readonly IPaymentHistoryRepository _paymentHistoryRepository;

    public PaymentHistoryCommandService(IPaymentHistoryRepository paymentHistoryRepository)
    {
        _paymentHistoryRepository = paymentHistoryRepository;
    }

    public void Dispose() => _paymentHistoryRepository.Dispose();


    public async Task CreatePaymentHistoryAsync(PaymentHistoryDtoForRegister paymentHistoryDtoForRegister)
    {
        var paymentHistory = paymentHistoryDtoForRegister.MapTo<PaymentHistoryDtoForRegister, PaymentHistory>();

        await _paymentHistoryRepository.SaveAsync(paymentHistory);
    }

}
