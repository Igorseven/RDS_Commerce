using Microsoft.EntityFrameworkCore.Query;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace RDS_Commerce.ApplicationServices.Services.ClientServices;
public sealed class ClientQueryService : IClientQueryService
{
    private readonly IClientRepository _clientRepository;

    public ClientQueryService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<Client?> FindByDomainObjectAsync(Expression<Func<Client, bool>> where, Func<IQueryable<Client>, IIncludableQueryable<Client, object>>? include = null, bool asNoTracking = false) =>
        await _clientRepository.FindByPredicateASync(where, include, asNoTracking);
}
