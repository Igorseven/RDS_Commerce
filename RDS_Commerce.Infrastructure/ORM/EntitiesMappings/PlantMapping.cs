using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Infrastructure.ORM.EntitiesMappings.BaseEntityMapping;

namespace RDS_Commerce.Infrastructure.ORM.EntitiesMappings;
public  class PlantMapping : BaseMapping, IEntityTypeConfiguration<Plant>
{
    public void Configure(EntityTypeBuilder<Plant> builder)
    {
        builder.ToTable(nameof(Plant), Schema);

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("id_plant");

        builder.Property(p => p.Name).HasColumnType("varchar(60)").IsUnicode(true).HasColumnName("name").IsRequired(true);

        builder.Property(p => p.Specie).HasColumnType("varchar(60)").IsUnicode(true).HasColumnName("specie").IsRequired(true);

        builder.Property(p => p.Description).HasColumnType("varchar(500)").IsUnicode(true).HasColumnName("description").IsSparse(true).IsRequired(false);

        builder.Property(p => p.Amount).HasColumnType("int").HasColumnName("amount").IsRequired(true);

        builder.Property(p => p.Price).HasColumnType("decimal(12,2)").HasColumnName("price").IsRequired(true);

        builder.Property(p => p.ProductType).HasColumnType("int").HasColumnName("product_type").IsRequired(true);

        builder.Property(p => p.RegistrationDate).HasColumnType("datetime2").HasColumnName("registration_date");
               

        builder.HasMany(p => p.Images).WithOne()
               .HasForeignKey(pi => pi.PlantId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
