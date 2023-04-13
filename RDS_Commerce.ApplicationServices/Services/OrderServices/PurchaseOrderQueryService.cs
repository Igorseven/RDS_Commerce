using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RDS_Commerce.ApplicationServices.AutoMapperSettings;
using RDS_Commerce.ApplicationServices.Dtos.Response.PurchaseOrderResponse;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace RDS_Commerce.ApplicationServices.Services.OrderServices;
public sealed class PurchaseOrderQueryService : IPurchaseOrderQueryService
{
    private readonly IPurchaseOrderRepository _orderRepository;

    public PurchaseOrderQueryService(IPurchaseOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<PurchaseOrder?> FindByDomainObjectAsync(Expression<Func<PurchaseOrder, bool>> where, Func<IQueryable<PurchaseOrder>, IIncludableQueryable<PurchaseOrder, object>>? include = null, bool AsNoTracking = false) =>
        await _orderRepository.FindByPredicateAsync(where, include, AsNoTracking);

    public async Task<PurchaseOrderDtoSearchResponse?> FindByOrderAsync(int orderId)
    {
        var order = await _orderRepository.FindByPredicateAsync(o => o.Id == orderId, 
                                                                i => i.Include(o => o.OrderPlants)
                                                                .ThenInclude(op => op.Plant)
                                                                .ThenInclude(p => p.Images), 
                                                                true);

        return order?.MapTo<PurchaseOrder, PurchaseOrderDtoSearchResponse>();
    }
}
