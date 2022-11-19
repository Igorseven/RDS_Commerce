namespace RDS_Commerce.Business.Interfaces.OthersContracts;
public interface IUnitOfWork
{
    void CommitTransaction();
    void RolbackTransaction();
    void BeginTransaction();
}
