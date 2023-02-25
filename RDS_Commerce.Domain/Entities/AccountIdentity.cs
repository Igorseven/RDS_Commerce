using Microsoft.AspNetCore.Identity;

namespace RDS_Commerce.Domain.Entities;
public sealed class AccountIdentity : IdentityUser
{
    public DateTime RegistrationDate { get; set; }
}
