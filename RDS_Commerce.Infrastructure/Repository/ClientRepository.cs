using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Infrastructure.ORM.ContextSettings;
using RDS_Commerce.Infrastructure.Repository.Base;
using System.Linq.Expressions;

namespace RDS_Commerce.Infrastructure.Repository;
public sealed class ClientRepository : BaseRepository<Client>, IClientRepository
{
    public ClientRepository(RdsApplicationDbContext context) : base(context)
    {
    }



    public async Task<bool> ExistInTheDatabaseAsync(Expression<Func<Client, bool>> where) => await _dbSetContext.AnyAsync(where);

    public async Task<Client?> FindByIdASync(Guid clientId, Func<IQueryable<Client>, IIncludableQueryable<Client, object>>? include, bool asNoTracking = false)
    {
        IQueryable<Client> query = _dbSetContext;

        if (asNoTracking)
            query = query.AsNoTracking();

        if (include is not null)
            query = include(query);

        return await query.FirstOrDefaultAsync(c => c.UserId == clientId);
    }

    public async Task<Client?> FindByPredicateASync(Expression<Func<Client, bool>> where, Func<IQueryable<Client>, IIncludableQueryable<Client, object>>? include, bool asNoTracking = false)
    {
        IQueryable<Client> query = _dbSetContext;

        if (asNoTracking)
            query = query.AsNoTracking();

        if (include is not null)
            query = include(query);

        return await query.FirstOrDefaultAsync(where);
    }

    public async Task<bool> SaveAsync(Client client)
    {
        _dbSetContext.Add(client);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> UpdateAsync(Client client)
    {
        _dbSetContext.Update(client);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> DeleteAsync(Guid clientId)
    {
        var client = await _dbSetContext.FindAsync(clientId);

        if (client is null)
            return false;

        if (_context.Entry(client).State == EntityState.Detached)
            _dbSetContext.Attach(client);

        _dbSetContext.Remove(client);

        return await SaveInDatabaseAsync();
    }
}
