using Microsoft.EntityFrameworkCore;
using RDS_Commerce.Domain.Entities;

namespace RDS_Commerce.Infrastructure.ORM.ContextSettings;
public class RdsApplicationDbContext : DbContext
{
    public DbSet<Plant> Plants { get; set; }
    public DbSet<PlantImage> PlantImages { get; set; }


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
                entry.Property("RegistrationDate").CurrentValue = DateTime.Now;

            if (entry.State == EntityState.Modified)
                entry.Property("RegistrationDate").IsModified = false;
        }

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }


}
