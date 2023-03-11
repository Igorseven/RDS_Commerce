using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RDS_Commerce.ApplicationServices.Interfaces;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Domain.Entities.Base;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RDS_Commerce.ApplicationServices.Services;
public sealed class AuthenticationTokenService<T> : IAuthenticationTokenService<T> where T : User
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<AccountIdentity> _userManager;
    public readonly SymmetricSecurityKey _key;

    public AuthenticationTokenService(IConfiguration configuration, UserManager<AccountIdentity> userManager)
    {
        _configuration = configuration;
        _userManager = userManager;
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtToken:JwtKey"]));
    }

    public async Task<string> GenerateTokenAsync(T entity, List<Claim>? claimList = null)
    {
        var claims = GetClaims(entity, claimList);

        var roles = await _userManager.GetRolesAsync(entity.AccountIdentity);

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescription = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddHours(5),
            SigningCredentials = creds
        };

        var tokeHandler = new JwtSecurityTokenHandler();

        var token = tokeHandler.CreateToken(tokenDescription);

        return tokeHandler.WriteToken(token);
    }

    private List<Claim> GetClaims(T user, List<Claim>? claimList)
    {
        var claimTokenList = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Name, user.AccountIdentity.UserName!)
        };

        if (claimList is not null)
            claimTokenList.AddRange(claimList);

        return claimTokenList;
    }
}
