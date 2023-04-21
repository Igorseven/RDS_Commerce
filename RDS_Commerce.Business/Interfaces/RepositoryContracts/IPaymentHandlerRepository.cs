using RDS_Commerce.Domain.Entities;

namespace RDS_Commerce.Business.Interfaces.RepositoryContracts;
public interface IPaymentHandlerRepository : IDisposable
{
    Task<bool> SaveAsync(PaymentHandler paymentHandler);
    Task<bool> UpdateAsync(PaymentHandler paymentHandler);
    Task<PaymentHandler?> FindByPredicateAsync(bool asNoTracking = false);

}
