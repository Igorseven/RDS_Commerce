using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Domain.Enums;
using RDS_Commerce.Infrastructure.ORM.EntitiesMappings.Base;

namespace RDS_Commerce.Infrastructure.ORM.EntitiesMappings;
public sealed class ClientMapping : BaseMapping, IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable(nameof(Client), Schema);
        builder.HasKey(c => c.ClientId);

        builder.Property(c => c.ClientId).HasColumnName("id_client");

        builder.Property(c => c.AccountIdentityId).HasColumnName("accountIdentity_id");

        builder.Property(c => c.FullName).HasColumnType("varchar(150)").IsUnicode(true)
               .HasColumnName("full_name").IsRequired(true);

        builder.Property(c => c.Role).HasColumnName("role").HasDefaultValue(ERole.Consumer).IsRequired(true);

        builder.Property(c => c.DocumentNumber).HasColumnType("varchar(20)")
               .HasColumnName("document_namber").IsRequired(true);

        builder.Property(c => c.RegistrationDate).HasColumnType("datetime2")
               .HasColumnName("registration_date");

        builder.HasOne(c => c.AccountIdentity)
               .WithOne()
               .HasForeignKey<Client>(c => c.AccountIdentityId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.ShippingAddresses)
               .WithOne()
               .HasForeignKey(sa => sa.ClientId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Orders)
               .WithOne(o => o.Client)
               .HasForeignKey(o => o.ClientId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
