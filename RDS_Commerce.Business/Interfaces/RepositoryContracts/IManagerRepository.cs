using Microsoft.EntityFrameworkCore.Query;
using RDS_Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace RDS_Commerce.Business.Interfaces.RepositoryContracts;
public interface IManagerRepository : IDisposable
{
    Task<bool> SaveAsync(Manager manager);
    Task<bool> UpdateAsync(Manager manager);
    Task<bool> DeleteAsync(Guid managerId);
    Task<Manager?> FindByIdAsync(Guid managerId, Func<IQueryable<Manager>, IIncludableQueryable<Manager, object>>? include, bool asNoTracking = false);
    Task<Manager?> FindByPredicateAsync(Expression<Func<Manager, bool>> where, Func<IQueryable<Manager>, IIncludableQueryable<Manager, object>>? include, bool asNoTracking = false);
    Task<bool> ExistInTheDatabaseAsync(Expression<Func<Manager, bool>> where);
}
