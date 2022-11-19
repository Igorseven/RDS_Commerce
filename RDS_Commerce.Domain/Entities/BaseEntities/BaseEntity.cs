namespace RDS_Commerce.Domain.Entities.BaseEntities;
public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime RegistrationDate { get; set; }
}
