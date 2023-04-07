using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Infrastructure.ORM.EntitiesMappings.Base;

namespace RDS_Commerce.Infrastructure.ORM.EntitiesMappings;
public sealed class OrderPlantMapping : BaseMapping, IEntityTypeConfiguration<OrderPlant>
{
    public void Configure(EntityTypeBuilder<OrderPlant> builder)
    {
        builder.ToTable(nameof(OrderPlant), Schema);
        builder.HasKey(op => op.OrderPlantId);

        builder.Property(op => op.OrderPlantId).HasColumnName("id_orderPlantId");

        builder.Property(op => op.OrderId).HasColumnName("order_id");

        builder.Property(op => op.PlantId).HasColumnName("plant_id");

        builder.Property(op => op.Quantity).HasColumnType("int").HasColumnName("quantity").IsRequired(true);

        builder.HasOne(op => op.Order)
               .WithMany(o => o.OrderPlants)
               .HasForeignKey(op => op.OrderId);

        builder.HasOne(op => op.Plant)
               .WithMany(p => p.OrderPlants)
               .HasForeignKey(op => op.PlantId);
    }
}
