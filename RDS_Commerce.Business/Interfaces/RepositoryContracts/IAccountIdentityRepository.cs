using Microsoft.AspNetCore.Identity;
using RDS_Commerce.Domain.Arguments;
using RDS_Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace RDS_Commerce.Business.Interfaces.RepositoryContracts;
public interface IAccountIdentityRepository : IDisposable
{
    Task<string> GenerateForgotPasswordTokenAsync(AccountIdentity accountIdentity);
    Task<IdentityResult> CreateAccountAsync(AccountIdentity accountIdentity);
    Task<IdentityResult> UpdateIdentityAsync(AccountIdentity accountIdentity);
    Task<SignInResult> SignPasswordAsync(string login, string password);
    Task<IdentityResult> ResetPasswordAsync(ResetPassword resetPassword);
    Task<AccountIdentity?> FindByPredicateAsync(Expression<Func<AccountIdentity, bool>> where, bool asNoTracking = false);
}
