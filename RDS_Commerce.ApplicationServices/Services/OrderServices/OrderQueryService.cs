using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Dtos.Response.OrderResponse;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace RDS_Commerce.ApplicationServices.Services.OrderServices;
public sealed class OrderQueryService : IOrderQueryService
{
    private readonly IOrderRepository _orderRepository;

    public OrderQueryService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Order?> FindByDomainObjectAsync(Expression<Func<Order, bool>> where, Func<IQueryable<Order>, IIncludableQueryable<Order, object>>? include = null, bool AsNoTracking = false) =>
        await _orderRepository.FindByPredicateAsync(where, include, AsNoTracking);

    public async Task<OrderDtoSearchResponse?> FindByOrderAsync(int orderId)
    {
        var order = await _orderRepository.FindByPredicateAsync(o => o.Id == orderId, i => i.Include(o => o.OrderPlants), true);

        return order?.MapTo<Order, OrderDtoSearchResponse>();
    }
}
