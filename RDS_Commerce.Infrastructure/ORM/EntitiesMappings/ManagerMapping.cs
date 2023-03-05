using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Infrastructure.ORM.EntitiesMappings.Base;

namespace RDS_Commerce.Infrastructure.ORM.EntitiesMappings;
public sealed class ManagerMapping : BaseMapping, IEntityTypeConfiguration<Manager>
{
    public void Configure(EntityTypeBuilder<Manager> builder)
    {
        builder.ToTable(nameof(Manager), Schema);
        builder.HasKey(m => m.ManagerId);

        builder.Property(m => m.ManagerId).HasColumnName("id_manager");

        builder.Property(m => m.AccountIdentityId).HasColumnName("accountIdentity_id");

        builder.Property(m => m.FullName).HasColumnType("varchar(150)").IsUnicode(true)
               .HasColumnName("full_name").IsRequired(true);

        builder.Property(m => m.Role).HasColumnName("role").IsRequired(true);

        builder.Property(m => m.Active).HasColumnType("bit").HasColumnName("active").IsRequired(true);

        builder.Property(m => m.RegistrationDate).HasColumnType("datetime2")
               .HasColumnName("registration_date");

        builder.HasOne(m => m.AccountIdentity)
               .WithOne()
               .HasForeignKey<Manager>(m => m.AccountIdentityId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
