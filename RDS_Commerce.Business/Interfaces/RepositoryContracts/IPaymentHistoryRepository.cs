using RDS_Commerce.Business.Handler.PaginationSettings;
using RDS_Commerce.Business.Handler.PaginationSettings.Filters;
using RDS_Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace RDS_Commerce.Business.Interfaces.RepositoryContracts;
public interface IPaymentHistoryRepository : IDisposable
{
    Task<bool> SaveAsync(PaymentHistory paymentHistory);
    Task<PaymentHistory?> FindByPredicateAsync(Expression<Func<PaymentHistory, bool>> where, bool asNoTracking = false);
    Task<PageList<PaymentHistory>>? FindAllWithPredicateAsync(PageParamsForPaymentHistory pageParams);
}
