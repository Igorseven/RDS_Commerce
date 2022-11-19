using RDS_Commerce.Business.Handler.ValidationSettings;

namespace RDS_Commerce.Business.Interfaces.OthersContracts;
public interface IValidate<T> where T : class
{
    Task<ValidationResponse> ValidationAsync(T entity);
}
