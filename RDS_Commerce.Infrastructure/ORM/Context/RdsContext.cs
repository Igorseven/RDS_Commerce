using Microsoft.EntityFrameworkCore;

namespace RDS_Commerce.Infrastructure.ORM.Context;
public class RdsContext : DbContext
{

	public RdsContext(DbContextOptions<RdsContext> dbContext)
		: base(dbContext)
	{

	}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RdsContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries()
                 .Where(entry => entry.Entity.GetType()
                 .GetProperty("CreationDate") != null))
        {
            if (entry.State == EntityState.Added)
                entry.Property("CreationDate").CurrentValue = DateTime.Now;

            if (entry.State == EntityState.Modified)
                entry.Property("CreationDate").IsModified = false;
        }

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}
