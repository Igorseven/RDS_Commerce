using Microsoft.EntityFrameworkCore.Query;
using RDS_Commerce.ApplicationServices.Dtos.Response.OrderResponse;
using RDS_Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IOrderQueryService
{
    Task<OrderDtoSearchResponse?> FindByOrderAsync(int orderId);
    Task<Order?> FindByDomainObjectAsync(Expression<Func<Order, bool>> where, 
                                        Func<IQueryable<Order>, IIncludableQueryable<Order, object>>? include = null,
                                        bool AsNoTracking = false);
}
