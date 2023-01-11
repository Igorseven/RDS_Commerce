using Microsoft.EntityFrameworkCore.Infrastructure;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Infrastructure.ORM.ContextSettings;

namespace RDS_Commerce.Infrastructure.ORM.UoW;
public sealed class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseFacade _databaseFacade;

	public UnitOfWork(RdsApplicationDbContext dbcontext)
	{
        _databaseFacade = dbcontext.Database;
    }

    public void CommitTransaction()
    {
        try
        {
            _databaseFacade.CommitTransaction();
        }
        catch
        {
            RolbackTransaction();
            throw;
        }
    }

    public void RolbackTransaction() => _databaseFacade.RollbackTransaction();

    public void BeginTransaction() => _databaseFacade.BeginTransaction();
}
