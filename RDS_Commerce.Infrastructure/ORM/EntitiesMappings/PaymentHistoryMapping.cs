using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Infrastructure.ORM.EntitiesMappings.Base;

namespace RDS_Commerce.Infrastructure.ORM.EntitiesMappings;
public sealed class PaymentHistoryMapping : BaseMapping, IEntityTypeConfiguration<PaymentHistory>
{
    public void Configure(EntityTypeBuilder<PaymentHistory> builder)
    {
        builder.ToTable(nameof(PaymentHistory), Schema);
        builder.HasKey(ph => ph.PaymentHistoryId);

        builder.Property(ph => ph.PaymentHistoryId).HasColumnName("id_paymentHistory");

        builder.Property(ph => ph.CustomerId).HasColumnType("varchar(250)").HasColumnName("customer_id");

        builder.Property(ph => ph.PaymentType).HasColumnName("payment_type").IsRequired(true);

        builder.Property(ph => ph.InstallmentNumber).HasColumnType("int")
               .HasColumnName("installment_number").IsRequired(false);

        builder.Property(ph => ph.PyamentValue).HasColumnType("int")
               .HasColumnName("installment_number").IsRequired(true);

        builder.Property(ph => ph.Status).HasColumnType("varchar(50)")
               .HasColumnName("status").IsRequired(true);

        builder.Property(ph => ph.PaymentDescription).HasColumnType("varchar(100)")
               .HasColumnName("status").IsRequired(true);

        builder.Property(ph => ph.ConfirmedDate).HasColumnType("datetime")
               .HasColumnName("confirmed_date").IsRequired(true);

        builder.Property(ph => ph.PaymentDate).HasColumnType("datetime")
               .HasColumnName("payment_date").IsRequired(true); 
        
        builder.Property(ph => ph.PixTransaction).HasColumnType("nvarchar(max)")
               .HasColumnName("pix_transaction").IsRequired(false);
    }
}
