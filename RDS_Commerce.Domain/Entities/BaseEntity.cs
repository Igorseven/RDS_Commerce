namespace RDS_Commerce.Domain.Entities;
public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
}
