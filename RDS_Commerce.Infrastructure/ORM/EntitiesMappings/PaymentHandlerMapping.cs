using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Infrastructure.ORM.EntitiesMappings.Base;

namespace RDS_Commerce.Infrastructure.ORM.EntitiesMappings;
public sealed class PaymentHandlerMapping : BaseMapping, IEntityTypeConfiguration<PaymentHandler>
{
    public void Configure(EntityTypeBuilder<PaymentHandler> builder)
    {
        builder.ToTable(nameof(PaymentHandler), Schema);
        builder.HasKey(ph => ph.PaymentHanlderId);

        builder.Property(ph => ph.PaymentHanlderId).HasColumnName("id_paymentHandler");

        builder.Property(ph => ph.PixKey).HasColumnType("varchar(250)").IsUnicode(true)
               .HasColumnName("pix_key").IsRequired(true);

        builder.Property(ph => ph.PaymentDescription).HasColumnType("varchar(100)").IsUnicode(true)
               .HasColumnName("payment_description").IsRequired(true);

        builder.Property(ph => ph.Discount).HasColumnType("int")
               .HasColumnName("discount").IsRequired(false);
    }
}
