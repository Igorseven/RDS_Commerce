using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Infrastructure.ORM.EntitiesMappings.Base;

namespace RDS_Commerce.Infrastructure.ORM.EntitiesMappings;
public sealed class ShippingAddressMapping : BaseMapping, IEntityTypeConfiguration<ShippingAddress>
{
    public void Configure(EntityTypeBuilder<ShippingAddress> builder)
    {
        builder.ToTable(nameof(ShippingAddress), Schema);
        builder.HasKey(sa => sa.Id);

        builder.Property(sa => sa.Id).HasColumnName("id_shippingAddress");

        builder.Property(sa => sa.ClientId).HasColumnName("client_id");

        builder.Property(sa => sa.State).HasColumnType("char(2)")
               .HasColumnName("state").IsRequired(true);

        builder.Property(sa => sa.City).HasColumnType("varchar(100)").IsUnicode(true)
               .HasColumnName("city").IsRequired(true);

        builder.Property(sa => sa.Street).HasColumnType("varchar(150)").IsUnicode(true)
               .HasColumnName("street").IsRequired(true);

        builder.Property(sa => sa.Complement).HasColumnType("varchar(250)").IsUnicode(true)
               .HasColumnName("complement").IsRequired(true);
        
        builder.Property(sa => sa.Destrict).HasColumnType("varchar(150)").IsUnicode(true)
               .HasColumnName("destrict").IsRequired(true);
        
        builder.Property(sa => sa.Country).HasColumnType("varchar(100)").IsUnicode(true)
               .HasColumnName("country").IsRequired(true);

        builder.Property(sa => sa.Number).HasColumnType("varchar(10)").IsUnicode(true)
               .HasColumnName("number").IsRequired(true);
        
        builder.Property(sa => sa.ZipCode).HasColumnType("varchar(10)").IsUnicode(true)
               .HasColumnName("zip_code").IsRequired(true);

        builder.Property(sa => sa.SelectedForShipping).HasColumnType("bit")
               .HasColumnName("selected_for_shipping").IsRequired(true);
    }
}
