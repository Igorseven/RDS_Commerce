using RDS_Commerce.ApplicationServices.Dtos.Response.PaymentHandlerResponse;
using RDS_Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IPaymentHandlerQueryService
{
    Task<PaymentHandlerDtoForSearchResponse?> FindByPaymentHanlderIdAsync(int paymentHanlderId);
    Task<PaymentHandler?> FindByDomainObjectAsync(bool asNoTracking = false); 
}
