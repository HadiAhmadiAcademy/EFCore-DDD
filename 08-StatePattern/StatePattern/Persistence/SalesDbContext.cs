using Microsoft.EntityFrameworkCore;
using StatePattern.Model;
using StatePattern.Persistence.Mappings;

namespace StatePattern.Persistence
{
    public class SalesDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EFCore-DDD_08_StatePattern;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderMapping).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}