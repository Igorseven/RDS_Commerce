using RDS_Commerce.Domain.Entities.Base;
using System.Security.Claims;

namespace RDS_Commerce.ApplicationServices.Interfaces;
public interface IAuthenticationTokenService
{
    Task<string> GenerateTokenAsync<T>(T entity, List<Claim>? claimList = null) where T : User;
}
