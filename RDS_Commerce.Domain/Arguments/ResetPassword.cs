using RDS_Commerce.Domain.Entities;

namespace RDS_Commerce.Domain.Arguments;
public sealed class ResetPassword
{
    public string Password { get; set; }
    public string Token { get; set; }

    public AccountIdentity AccountIdentity { get; set; }
}
