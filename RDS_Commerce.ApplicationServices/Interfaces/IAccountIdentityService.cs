using RDS_Commerce.ApplicationServices.Dtos.Arguments;
using RDS_Commerce.Domain.Entities;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IAccountIdentityService : IDisposable
{
    Task<AccountIdentity?> GetAccountIdentityLoginAsync(UserLogin userLogin);
    Task<bool> CreateIdentityAccountAsync(AccountIdentity accountIdentity);
    Task<bool> SignPasswordAsync(UserLogin login);
}