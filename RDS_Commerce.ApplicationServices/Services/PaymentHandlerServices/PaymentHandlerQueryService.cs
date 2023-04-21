using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Dtos.Response.PaymentHandlerResponse;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;

namespace RDS_Commerce.ApplicationServices.Services.PaymentHandlerServices;
public sealed class PaymentHandlerQueryService : IPaymentHandlerQueryService
{
    private readonly IPaymentHandlerRepository _paymentHandlerRepository;

    public PaymentHandlerQueryService(IPaymentHandlerRepository paymentHandlerRepository)
    {
        _paymentHandlerRepository = paymentHandlerRepository;
    }

    public async Task<PaymentHandler?> FindByDomainObjectAsync(bool asNoTracking = false) => 
        await _paymentHandlerRepository.FindByPredicateAsync(asNoTracking);

    public async Task<PaymentHandlerDtoForSearchResponse?> FindByPaymentHanlderIdAsync(int paymentHanlderId)
    {
        var paymentHandler = await _paymentHandlerRepository.FindByPredicateAsync(true);

        return paymentHandler?.MapTo<PaymentHandler, PaymentHandlerDtoForSearchResponse>();
    }
}
