using Microsoft.EntityFrameworkCore;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Infrastructure.ORM.ContextSettings;
using RDS_Commerce.Infrastructure.Repository.Base;
using System.Linq.Expressions;

namespace RDS_Commerce.Infrastructure.Repository;
public sealed class ShippingAddressRepository : BaseRepository<ShippingAddress>, IShippingAddressRepository
{
    public ShippingAddressRepository(RdsApplicationDbContext context) 
        : base(context)
    {
    }


    public async Task<List<ShippingAddress>?> FindAllAsync(Expression<Func<ShippingAddress, bool>> where)
    {
        IQueryable<ShippingAddress> query = _dbSetContext;

        query = query.Where(where);

        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<ShippingAddress?> FindByIdAsync(int shippingAddressId, bool asNoTracking = false)
    {
        IQueryable<ShippingAddress> query = _dbSetContext;

        if (asNoTracking)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(sa => sa.Id == shippingAddressId);
    }

    public async Task<ShippingAddress?> FindByPredicateAsync(Expression<Func<ShippingAddress, bool>> where, bool asNoTracking = false)
    {
        IQueryable<ShippingAddress> query = _dbSetContext;

        if (asNoTracking)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(where);
    }

    public async Task<bool> SaveAsync(ShippingAddress shippingAddress)
    {
        _dbSetContext.Add(shippingAddress);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> UpdateAsync(ShippingAddress shippingAddress)
    {
        _dbSetContext.Update(shippingAddress);
        _context.Entry(shippingAddress).State = EntityState.Modified;

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> DeleteAsync(int shippingAddressId)
    {
        var shippingAddress = await _dbSetContext.FindAsync(shippingAddressId);

        if (shippingAddress is null) return false;

        DetachedObject(shippingAddress);

        _dbSetContext.Remove(shippingAddress);

        return await SaveInDatabaseAsync();
    }
}
