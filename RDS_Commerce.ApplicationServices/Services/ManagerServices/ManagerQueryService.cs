using Microsoft.EntityFrameworkCore.Query;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace RDS_Commerce.ApplicationServices.Services.ManagerServices;
public sealed class ManagerQueryService : IManagerQueryService
{
    private readonly IManagerRepository _managerRepository;

    public ManagerQueryService(IManagerRepository managerRepository)
    {
        _managerRepository = managerRepository;
    }

    public async Task<Manager?> FindByDomainObjectAsync(Expression<Func<Manager, bool>> where, Func<IQueryable<Manager>, IIncludableQueryable<Manager, object>>? include = null, bool asNoTracking = false) =>
        await _managerRepository.FindByPredicateAsync(where, include, asNoTracking);
}
