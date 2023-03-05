using Microsoft.EntityFrameworkCore;

namespace RDS_Commerce.Infrastructure.ORM.ContextSettings;
public class RdsApplicationDbContext : DbContext
{

    public RdsApplicationDbContext(DbContextOptions<RdsApplicationDbContext> options)
		: base(options)
	{

	}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.EnableDetailedErrors();

        base.OnConfiguring(optionsBuilder);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RdsApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries()
                 .Where(entry => entry.Entity.GetType()
                 .GetProperty("RegistrationDate") != null))
        {
            if (entry.State == EntityState.Added)
                entry.Property("RegistrationDate").CurrentValue = DateTime.UtcNow.AddHours(-3);

            if (entry.State == EntityState.Modified)
                entry.Property("RegistrationDate").IsModified = false;
        }

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }


}
