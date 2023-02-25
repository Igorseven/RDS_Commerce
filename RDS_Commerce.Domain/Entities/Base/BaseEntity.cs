namespace RDS_Commerce.Domain.Entities.Base;
public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime RegistrationDate { get; set; }
}
