using Microsoft.EntityFrameworkCore.Query;
using RDS_Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace RDS_Commerce.Business.Interfaces.RepositoryContracts;
public interface IGenusRespository : IDisposable
{
    Task<bool> SaveAsync(Genus genus);
    Task<bool> UpdateAsync(Genus genus);
    Task<bool> DeleteAsync(int genusId);
    Task<Genus?> FindByAsync(int genusId, Func<IQueryable<Genus>, IIncludableQueryable<Genus, Object>>? include = null, bool asNoTracking = false);
    Task<Genus?> FindByNameAsync(Expression<Func<Genus, bool>> where, bool asNoTracking = false);
}
