using Microsoft.EntityFrameworkCore.Query;
using RDS_Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IManagerQueryService
{
    Task<Manager?> FindByDomainObjectAsync(Expression<Func<Manager, bool>> where, Func<IQueryable<Manager>, IIncludableQueryable<Manager, object>>? include = null, bool asNoTracking = false);

}
