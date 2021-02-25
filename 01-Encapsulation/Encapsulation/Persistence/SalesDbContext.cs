using Encapsulation.Model;
using Encapsulation.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Encapsulation.Persistence
{
    public class SalesDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EFCore-DDD;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerMapping).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}