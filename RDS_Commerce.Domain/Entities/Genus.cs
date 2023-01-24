using RDS_Commerce.Domain.Entities.BaseEntities;

namespace RDS_Commerce.Domain.Entities;
public sealed class Genus : BaseEntity
{
    public string GenusName { get; set; }
    public string Specie { get; set; }

    public List<Plant>? Plants { get; set; }
}
