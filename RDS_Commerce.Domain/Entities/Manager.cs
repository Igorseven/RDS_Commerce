using RDS_Commerce.Domain.Enums;

namespace RDS_Commerce.Domain.Entities;
public sealed class Manager
{
    public Guid ManagerId { get; set; }
    public string FullName { get; set; }
    public ERole Role { get; set; }
    public bool Active { get; set; }
    public DateTime RegistrationDate { get; set; }


    public Guid AccountIdentityId { get; set; }
    public AccountIdentity AccountIdentity { get; set; }
}
