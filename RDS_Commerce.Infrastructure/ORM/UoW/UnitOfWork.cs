using Microsoft.EntityFrameworkCore.Infrastructure;
using RDS_Commerce.Business.Interfaces.OthersContracts;
using RDS_Commerce.Infrastructure.ORM.Context;

namespace RDS_Commerce.Infrastructure.ORM.UoW;
public sealed class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseFacade _databaseFacade;

	public UnitOfWork(RdsContext dbcontext)
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
            _databaseFacade.RollbackTransaction();
            throw;
        }
    }

    public void RolbackTransaction() => _databaseFacade.RollbackTransaction();

    public void BeginTransaction() => _databaseFacade.BeginTransaction();
}
