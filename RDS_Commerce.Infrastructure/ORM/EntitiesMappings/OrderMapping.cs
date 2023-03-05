using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Infrastructure.ORM.EntitiesMappings.Base;

namespace RDS_Commerce.Infrastructure.ORM.EntitiesMappings;
public sealed class OrderMapping : BaseMapping, IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable(nameof(Order), Schema);
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id).HasColumnName("id_order");

        builder.Property(o => o.OrderStatus).HasColumnName("order_status").IsRequired(true);

        builder.Property(o => o.Amount).HasColumnType("decimal(12,2)")
               .HasColumnName("amount").IsRequired(true);

        builder.HasMany(o => o.Plants)
               .WithMany(p => p.Orders)
               .UsingEntity<Dictionary<string, object>>("OrderPlant",
                    dc => dc.HasOne<Plant>().WithMany().HasForeignKey("plant_id"),
                    dc => dc.HasOne<Order>().WithMany().HasForeignKey("orde_id")
               );
    }
}
