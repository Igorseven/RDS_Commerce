using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.Domain.Entities.Base;
public abstract class User
{
    public Guid UserId { get; set; }
    public string FullName { get; set; }
    public ERole Role { get; set; }
    public DateTime RegistrationDate { get; set; }


    public string AccountIdentityId { get; set; }
    public AccountIdentity AccountIdentity { get; set; }
}
