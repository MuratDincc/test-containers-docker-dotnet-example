using Microsoft.EntityFrameworkCore;

namespace Customer.Api.Data;

public class CustomerApiContext : DbContext
{
    public CustomerApiContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Entities.Customer> Customer { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("dbo");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerApiContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}