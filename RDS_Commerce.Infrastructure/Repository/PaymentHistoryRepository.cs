using Microsoft.EntityFrameworkCore;
using RDS_Commerce.Business.Handler.PaginationSettings;
using RDS_Commerce.Business.Handler.PaginationSettings.Filters;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Infrastructure.ORM.ContextSettings;
using RDS_Commerce.Infrastructure.Repository.Base;
using System.Linq.Expressions;

namespace RDS_Commerce.Infrastructure.Repository;
public sealed class PaymentHistoryRepository : BaseRepository<PaymentHistory>, IPaymentHistoryRepository
{
    private readonly IPaginationService<PaymentHistory> _paginationService;

    public PaymentHistoryRepository(RdsApplicationDbContext context,
                                    IPaginationService<PaymentHistory> paginationService)
        : base(context)
    {
        _paginationService = paginationService;
    }

    public async Task<PageList<PaymentHistory>>? FindAllWithPredicateAsync(PageParamsForPaymentHistory pageParams)
    {
        IQueryable<PaymentHistory> query = _dbSetContext;


        query = QueryFilter(query, pageParams);

        return await _paginationService.CreatePaginationAsync(query, pageParams.PageSize, pageParams.PageNumber);
    }

    public async Task<PaymentHistory?> FindByPredicateAsync(Expression<Func<PaymentHistory, bool>> where, bool asNoTracking = false)
    {
        IQueryable<PaymentHistory> query = _dbSetContext;

        if (asNoTracking)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(where);
    }

    public async Task<bool> SaveAsync(PaymentHistory paymentHistory)
    {
        _dbSetContext.Add(paymentHistory);

        return await SaveInDatabaseAsync();
    }

    private static IQueryable<PaymentHistory> QueryFilter(IQueryable<PaymentHistory> query, PageParamsForPaymentHistory pageParams)
    {
        if (pageParams.PaymentType is not null)
            query = query.Where(ph => ph.PaymentType == pageParams.PaymentType);

        if (pageParams.InstallmentNumber is not null)
            query = query.Where(ph => ph.InstallmentNumber == pageParams.InstallmentNumber);

        if (pageParams.PaymentDescription is not null)
            query = query.Where(ph => ph.PaymentDescription.Contains(pageParams.PaymentDescription));

        if (pageParams.PaymentDate is not null)
            query = query.Where(ph => ph.PaymentDate == pageParams.PaymentDate.Value);

        return query;
    }
}
