using Microsoft.EntityFrameworkCore.Query;
using RDS_Commerce.ApplicationServices.Dtos.Response.PurchaseOrderResponse;
using RDS_Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IPurchaseOrderQueryService
{
    Task<PurchaseOrderDtoSearchResponse?> FindByOrderAsync(int orderId);
    Task<PurchaseOrder?> FindByDomainObjectAsync(Expression<Func<PurchaseOrder, bool>> where, 
                                                 Func<IQueryable<PurchaseOrder>, IIncludableQueryable<PurchaseOrder, object>>? include = null,
                                                 bool AsNoTracking = false);
}
