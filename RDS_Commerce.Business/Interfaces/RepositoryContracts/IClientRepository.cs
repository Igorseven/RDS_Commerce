using Microsoft.EntityFrameworkCore.Query;
using RDS_Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace RDS_Commerce.Business.Interfaces.RepositoryContracts;
public interface IClientRepository : IDisposable
{
    Task<bool> SaveAsync(Client client);
    Task<bool> UpdateAsync(Client client);
    Task<bool> DeleteAsync(Guid clientId);
    Task<bool> ExistInTheDatabaseAsync(Expression<Func<Client, bool>> where);
    Task<Client?> FindByIdASync(Guid clientId, Func<IQueryable<Client>, IIncludableQueryable<Client, object>>? include, bool asNoTracking = false);
    Task<Client?> FindByPredicateASync(Expression<Func<Client, bool>> where, Func<IQueryable<Client>, IIncludableQueryable<Client, object>>? include, bool asNoTracking = false);
}
