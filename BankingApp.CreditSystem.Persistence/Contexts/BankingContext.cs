using BankingApp.CreditSystem.Domain.Entities;
using BankingApp.CreditSystem.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.CreditSystem.Persistence.Contexts;

public class BankingContext : DbContext
{
    public BankingContext(DbContextOptions<BankingContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<IndividualCustomer> IndividualCustomers { get; set; }
    public DbSet<CorporateCustomer> CorporateCustomers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration());
        modelBuilder.ApplyConfiguration(new IndividualCustomerEntityConfiguration());
        modelBuilder.ApplyConfiguration(new CorporateCustomerEntityConfiguration());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateTimestamps();
        return await base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        UpdateTimestamps();
        return base.SaveChanges();
    }

    private void UpdateTimestamps()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        foreach (var entry in entries)
        {
            if (entry.Entity is Customer customer)
            {
                if (entry.State == EntityState.Added)
                {
                    customer.CreatedDate = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    customer.UpdatedDate = DateTime.UtcNow;
                }
            }
        }
    }
} 