using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Infrastructure.ORM.EntitiesMappings.Base;

namespace RDS_Commerce.Infrastructure.ORM.EntitiesMappings;
public sealed class AccountIdentityMapping : BaseMapping, IEntityTypeConfiguration<AccountIdentity>
{
    public void Configure(EntityTypeBuilder<AccountIdentity> builder)
    {
        builder.ToTable(nameof(AccountIdentity), Schema);
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("id_accountIdentity");

        builder.Property(a => a.UserName).HasColumnName("login");

        builder.Property(a => a.PasswordHash).HasColumnName("password");

        builder.Property(a => a.Email).HasColumnName("email");

        builder.Property(a => a.EmailConfirmed).HasColumnName("email_confirmed");

        builder.Property(a => a.PhoneNumber).HasColumnName("cell_phone");

        builder.Property(a => a.PhoneNumberConfirmed).HasColumnName("cell_phone_confirmed");

        builder.Property(a => a.AccessFailedCount).HasColumnName("access_failed_count");

        builder.Property(a => a.NormalizedEmail).HasColumnName("normalized_email");

        builder.Property(a => a.NormalizedUserName).HasColumnName("normalized_login");

        builder.Property(a => a.LockoutEnabled).HasColumnName("lockout_enabled");

        builder.Property(a => a.ConcurrencyStamp).HasColumnName("concurrency_stamp");

        builder.Property(a => a.SecurityStamp).HasColumnName("security_stamp");

        builder.Property(a => a.TwoFactorEnabled).HasColumnName("two_factor_enabled");

        builder.Property(a => a.RegistrationDate).HasColumnType("date")
               .HasColumnName("registration_date");
    }
}
