using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Infrastructure.ORM.EntitiesMappings.BaseEntityMapping;

namespace RDS_Commerce.Infrastructure.ORM.EntitiesMappings;
public sealed class GenusMapping : BaseMapping, IEntityTypeConfiguration<Genus>
{
    public void Configure(EntityTypeBuilder<Genus> builder)
    {
        builder.ToTable(nameof(Genus), Schema);
        builder.HasKey(g => g.Id);

        builder.Property(g => g.Id).HasColumnType("int").HasColumnName("Id_Genus");

        builder.Property(g => g.GenusName).HasColumnType("varchar(80)")
               .IsUnicode(true).HasColumnName("genus_name").IsRequired(true);

        builder.Property(g => g.Specie).HasColumnType("varchar(60)")
               .IsUnicode(true).HasColumnName("specie").IsRequired(true);

        builder.HasMany(g => g.Plants)
               .WithOne(p => p.Genus)
               .HasForeignKey(p => p.GenusId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}
