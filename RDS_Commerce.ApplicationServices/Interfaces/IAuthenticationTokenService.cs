using RDS_Commerce.Domain.Entities.Base;
using System.Security.Claims;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IAuthenticationTokenService<T> where T : User
{
    Task<string> GenerateTokenAsync(T entity, List<Claim>? claimList = null);
}
