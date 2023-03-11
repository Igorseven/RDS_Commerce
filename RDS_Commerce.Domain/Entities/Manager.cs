using RDS_Commerce.Domain.Entities.Base;

namespace RDS_Commerce.Domain.Entities;
public sealed class Manager : User
{
    public bool Active { get; set; }
}
