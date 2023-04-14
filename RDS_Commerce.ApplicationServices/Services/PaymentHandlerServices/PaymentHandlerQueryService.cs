using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Dtos.Response.PaymentHandlerResponse;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace RDS_Commerce.ApplicationServices.Services.PaymentHandlerServices;
public sealed class PaymentHandlerQueryService : IPaymentHandlerQueryService
{
    private readonly IPaymentHandlerRepository _paymentHandlerRepository;

    public PaymentHandlerQueryService(IPaymentHandlerRepository paymentHandlerRepository)
    {
        _paymentHandlerRepository = paymentHandlerRepository;
    }

    public async Task<PaymentHandler?> FindByDomainObjectAsync(Expression<Func<PaymentHandler, bool>> where, bool asNoTracking = false) => 
        await _paymentHandlerRepository.FindByPredicateAsync(where, asNoTracking);

    public async Task<PaymentHandlerDtoForSearchResponse?> FindByPaymentHanlderIdAsync(int paymentHanlderId)
    {
        var paymentHandler = await _paymentHandlerRepository.FindByPredicateAsync(ph => ph.PaymentHanlderId == paymentHanlderId, true);

        return paymentHandler?.MapTo<PaymentHandler, PaymentHandlerDtoForSearchResponse>();
    }
}
