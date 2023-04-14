using Microsoft.EntityFrameworkCore;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Infrastructure.ORM.ContextSettings;
using RDS_Commerce.Infrastructure.Repository.Base;
using System.Linq.Expressions;

namespace RDS_Commerce.Infrastructure.Repository;
public sealed class PaymentHandlerRepository : BaseRepository<PaymentHandler>, IPaymentHandlerRepository
{
    public PaymentHandlerRepository(RdsApplicationDbContext context) : base(context)
    {
    }

    public async Task<PaymentHandler?> FindByPredicateAsync(Expression<Func<PaymentHandler, bool>> where, bool asNoTracking = false)
    {
        IQueryable<PaymentHandler> query = _dbSetContext;

        if (asNoTracking)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(where);
    }

    public async Task<bool> SaveAsync(PaymentHandler paymentHandler)
    {
        _dbSetContext.Add(paymentHandler);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> UpdateAsync(PaymentHandler paymentHandler)
    {
        _dbSetContext.Update(paymentHandler);
        _context.Entry(paymentHandler).State = EntityState.Modified;

        return await SaveInDatabaseAsync();
    }
}
