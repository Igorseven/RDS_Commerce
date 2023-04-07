using Microsoft.EntityFrameworkCore.Query;
using RDS_Commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IClientQueryService
{
    Task<Client?> FindByDomainObjectAsync(Expression<Func<Client, bool>> where, Func<IQueryable<Client>, IIncludableQueryable<Client, object>>? include = null, bool asNoTracking = false);
}
