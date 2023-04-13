using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Infrastructure.ORM.EntitiesMappings.Base;

namespace RDS_Commerce.Infrastructure.ORM.EntitiesMappings;
public sealed class PurchaseOrderMapping : BaseMapping, IEntityTypeConfiguration<PurchaseOrder>
{
    public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
    {
        builder.ToTable(nameof(PurchaseOrder), Schema);
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id).HasColumnName("id_order");

        builder.Property(o => o.OrderStatus).HasColumnName("order_status").IsRequired(true);

        builder.Property(o => o.Amount).HasColumnType("decimal(12,2)")
               .HasColumnName("amount").IsRequired(true);
    }
}
