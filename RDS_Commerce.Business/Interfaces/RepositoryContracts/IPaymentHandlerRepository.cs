using RDS_Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace RDS_Commerce.Business.Interfaces.RepositoryContracts;
public interface IPaymentHandlerRepository : IDisposable
{
    Task<bool> SaveAsync(PaymentHandler paymentHandler);
    Task<bool> UpdateAsync(PaymentHandler paymentHandler);
    Task<PaymentHandler?> FindByPredicateAsync(Expression<Func<PaymentHandler, bool>> where, bool asNoTracking = false);

}
